using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(PlayerInput))]
public class Character : Actor
{
	#region PRIVATE_PROPERTIES
	[SerializeField] private List<Gun> _guns;
    [SerializeField] private Gun _currentGun;
    [SerializeField] private float _jumpHeight;
    [SerializeField] private float _gravityValue;
    [SerializeField] private CharacterStats _characterStats;

    private CharacterController _controller;
    private PlayerInput _playerInput;
    [SerializeField] private Vector3 _playerVelocity;
    private Transform _cameraTransform;

    public bool freeze;
    public bool activeGrapple;
	#endregion

	#region GUN_COMMAND
	private CmdShoot _cmdShoot;
    private CmdReload _cmdReload;
    #endregion

    #region INPUT_ACTIONS
    private InputAction _moveAction;
    private InputAction _jumpAction;
    private InputAction _shootAction;

    private void InitInputActions() {
        _moveAction = _playerInput.actions["Move"];
        _jumpAction = _playerInput.actions["Jump"];
        _shootAction = _playerInput.actions["Shoot"];
	}

	#endregion

	#region KEY_BINDINGS

	[SerializeField] private KeyCode _moveForward = KeyCode.W;
    [SerializeField] private KeyCode _moveBack = KeyCode.S;
    [SerializeField] private KeyCode _moveLeft = KeyCode.A;
    [SerializeField] private KeyCode _moveRight = KeyCode.D;

    [SerializeField] private KeyCode _attack = KeyCode.Mouse0;
    [SerializeField] private KeyCode _reload = KeyCode.R;

    [SerializeField] private KeyCode _gunSlot1 = KeyCode.Alpha1;
    [SerializeField] private KeyCode _gunSlot2 = KeyCode.Alpha2;
    [SerializeField] private KeyCode _gunSlot3 = KeyCode.Alpha3;

    #endregion

    private void Awake() {
        _playerInput = GetComponent<PlayerInput>();
        InitInputActions();

        _controller = GetComponent<CharacterController>();
        base.stats = _characterStats;
        SwitchGuns(0);
        _cameraTransform = Camera.main.transform;

        Cursor.lockState = CursorLockMode.Locked;
    }

	private void OnEnable() {
        _shootAction.performed += _ => {
            EventQueueManager.instance.AddCommand(_cmdShoot);
            EventsManager.instance.EventShoot(_currentGun.Stats.ShootAudioClip);
        };
    }

	private void OnDisable() {
        _shootAction.performed -= _ => EventQueueManager.instance.AddCommand(_cmdShoot);
    }

	// Start is called before the first frame update
	private void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    private void Update()
    {

        // Shoot Bullet
        if (Input.GetKeyDown(_reload)) {
            EventQueueManager.instance.AddCommand(_cmdReload);
            EventsManager.instance.EventReload(_currentGun.Stats.ReloadAudioClip);
        }

        if (Input.GetKeyDown(_gunSlot1)) SwitchGuns(0);
        if (Input.GetKeyDown(_gunSlot2)) SwitchGuns(1);
        if (Input.GetKeyDown(_gunSlot3)) SwitchGuns(2);

        GameManager.instance.UpdateAmmoCount(_currentGun._currentBulletCount);

        CharacterMovement();
    }

    private void CharacterMovement()
    {
        bool groundedPlayer = _controller.isGrounded;

        if (activeGrapple && groundedPlayer) {
            _playerVelocity = Vector3.zero;
            activeGrapple = false;
		}

        if (groundedPlayer && _playerVelocity.y < 0) {
            _playerVelocity.y = 0f;
        }

        if (CanMove()) {
            Vector2 moveInput = _moveAction.ReadValue<Vector2>();
            Vector3 move = new Vector3(moveInput.x, 0, moveInput.y);
            move = move.x * _cameraTransform.right.normalized + move.z * _cameraTransform.forward.normalized;
            move.y = 0f;
            EventQueueManager.instance.AddCommand(new CmdMove(_controller, move * Time.deltaTime * _characterStats.MovementSpeed));
        }
        
        if (_jumpAction.triggered && groundedPlayer) {
            _playerVelocity.y += Mathf.Sqrt(_jumpHeight * -3.0f * _gravityValue);
        }

        _playerVelocity.y += _gravityValue * Time.deltaTime;

        EventQueueManager.instance.AddCommand(new CmdMove(_controller, _playerVelocity * Time.deltaTime));

        // Rotate towards camera direction
        Quaternion tagetRotation = Quaternion.Euler(0, _cameraTransform.eulerAngles.y, 0);
        transform.rotation = Quaternion.Lerp(transform.rotation, tagetRotation, _characterStats.RotationSpeed);
    }

    private bool CanMove() {
        return !activeGrapple;
	}

    private void SwitchGuns(int index)
    {
        foreach (Gun gun in _guns)
        {
            gun.gameObject.SetActive(false);
        }

        _guns[index].gameObject.SetActive(true);
        _currentGun = _guns[index];
        _cmdShoot = new CmdShoot(_currentGun);
        _cmdReload = new CmdReload(_currentGun);
    }

    public void JumpToPosition(Vector3 targetPosition, float trajetoryHeight) {
        _playerVelocity = CalculateJumpVelocity(transform.position, targetPosition, trajetoryHeight);

        Invoke(nameof(ActivateGrapple), 0.11f);
	}

    private void ActivateGrapple() {
        activeGrapple = true;
    }

    public Vector3 CalculateJumpVelocity(Vector3 startPoint, Vector3 endpoint, float trajectoryHeight) {
        float displacementY = endpoint.y - startPoint.y;
        Vector3 displacementXZ = new Vector3(endpoint.x - startPoint.x, 0f, endpoint.z - startPoint.z);

        Vector3 velocityY = Vector3.up * Mathf.Sqrt(-2 * _gravityValue * trajectoryHeight);
        Vector3 velocityXZ = displacementXZ / (Mathf.Sqrt(-2 * trajectoryHeight / _gravityValue)
            + Mathf.Sqrt(2 * (displacementY - trajectoryHeight) / _gravityValue));

        return velocityXZ + velocityY;
	}
}