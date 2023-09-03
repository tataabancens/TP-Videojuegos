using System.Collections.Generic;
using UnityEngine;

public class Character : Actor, IMoveable
{
    [SerializeField] private List<Gun> _guns;
    [SerializeField] private Gun _currentGun;

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
    }

    // Update is called once per frame
    private void Update()
    {
        // Move forward
        if (Input.GetKey(_moveForward)) Move(Vector3.forward);
        // Move back
        if (Input.GetKey(_moveBack)) Move(-Vector3.forward);
        // Move left
        if (Input.GetKey(_moveLeft)) Move(-Vector3.right);
        // Move right
        if (Input.GetKey(_moveRight)) Move(Vector3.right);

        // Shoot Bullet
        if (Input.GetKeyDown(_attack)) _currentGun.Shoot();
        // Reload
        if (Input.GetKeyDown(_reload)) _currentGun.Reload();

        if (Input.GetKeyDown(_gunSlot1)) SwitchGuns(0);
        if (Input.GetKeyDown(_gunSlot2)) SwitchGuns(1);
        if (Input.GetKeyDown(_gunSlot3)) SwitchGuns(2);
 
    }

    #region IMOVEABLE_PROPERTIES

    [SerializeField] private float _speed = 5f;
    public float MovementSpeed => _speed;
    public void Move(Vector3 direction) => transform.position += direction * (Time.deltaTime * MovementSpeed);

    #endregion

    private void SwitchGuns(int index)
    {
        foreach (Gun gun in _guns)
        {
            gun.gameObject.SetActive(false);
        }

        _guns[index].gameObject.SetActive(true);
        _currentGun = _guns[index];
    }
}