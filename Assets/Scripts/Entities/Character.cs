using System.Collections.Generic;
using UnityEngine;

public class Character : Actor
{
    [SerializeField] private List<Gun> _guns;
    [SerializeField] private Gun _currentGun;
    private MovementController _movementController;

    #region GUN_COMMAND
    private CmdShoot _cmdShoot;
    private CmdReload _cmdReload;
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


    // Start is called before the first frame update
    private void Start()
    {
        base.Start();
        SwitchGuns(0);
        _movementController = GetComponent<MovementController>();

        InitMovementCommands();
    }

    // Update is called once per frame
    private void Update()
    {

        // Shoot Bullet
        if (Input.GetKeyDown(_attack)) EventQueueManager.instance.AddCommand(_cmdShoot);
        if (Input.GetKeyDown(_reload)) EventQueueManager.instance.AddCommand(_cmdReload);

        if (Input.GetKeyDown(_gunSlot1)) SwitchGuns(0);
        if (Input.GetKeyDown(_gunSlot2)) SwitchGuns(1);
        if (Input.GetKeyDown(_gunSlot3)) SwitchGuns(2);

        //end game conditions
        if (Input.GetKeyDown(KeyCode.Return)) EventsManager.instance.EventGameOver(true);
        if (Input.GetKeyDown(KeyCode.Backspace)) TakeDamage(25);


    }

    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.Backspace)) Debug.Log(EventQueueManager.instance);
        // Move forward
        if (Input.GetKey(_moveForward)) EventQueueManager.instance.AddCommand(_cmdMoveForward);
        // Move back
        if (Input.GetKey(_moveBack)) EventQueueManager.instance.AddCommand(_cmdMoveBack);
        // Move left
        if (Input.GetKey(_moveLeft)) EventQueueManager.instance.AddCommand(_cmdRotateLeft);
        // Move right
        if (Input.GetKey(_moveRight)) EventQueueManager.instance.AddCommand(_cmdRotateRight);
    }

    #region MOVEMENT_COMMAND
    private CmdMovement _cmdMoveForward;
    private CmdMovement _cmdMoveBack;
    private CmdMovement _cmdMoveRight;
    private CmdMovement _cmdMoveLeft;
    private CmdRotateActor _cmdRotateLeft;
    private CmdRotateActor _cmdRotateRight;

    private void InitMovementCommands()
    {
        _cmdMoveForward = new CmdMovement(_movementController, Vector3.forward);
        _cmdMoveBack = new CmdMovement(_movementController, -Vector3.forward);
        _cmdMoveRight = new CmdMovement(_movementController, Vector3.right);
        _cmdMoveLeft = new CmdMovement(_movementController, -Vector3.right);
        _cmdMoveBack = new CmdMovement(_movementController, -Vector3.forward);
        _cmdRotateLeft = new CmdRotateActor(_movementController, -Vector3.up);
        _cmdRotateRight = new CmdRotateActor(_movementController, Vector3.up);
    }
    #endregion

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
}