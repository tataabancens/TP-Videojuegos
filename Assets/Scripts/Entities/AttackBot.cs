using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackBot : MonoBehaviour, IFreezable { 
    [SerializeField] private Transform ball;
    [SerializeField] private CharacterStats _characterStats;
    private CharacterController _controller;

    [SerializeField] private Gun _currentGun;
    private Vector3 _startPosition;

    [Header("Cooldown")]
    [SerializeField] private float rightGunCd;
    [SerializeField] private float rightGunCdTimer;
    // Start is called before the first frame update

    private bool _freezed;
    [SerializeField] private float freezeCd;
    [SerializeField] private float freezeTimer;

    void Start()
    {
        rightGunCdTimer = rightGunCd;
        _controller = GetComponent<CharacterController>();
        _startPosition = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        _freezed = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (_freezed) {
            freezeTimer -= Time.deltaTime;
            if (freezeTimer < 0) UnFreeze();
            return;
        }

        Vector3 distanceFromStartVec = _startPosition - transform.position;
        float moveAmount = Time.deltaTime * _characterStats.MovementSpeed;

        
            Vector3 directionToCenter = new Vector3(distanceFromStartVec.x, 0, distanceFromStartVec.z);
        if (directionToCenter.magnitude + moveAmount > 0.5f) {
            transform.position += directionToCenter.normalized * moveAmount;
        }
      
        // Rotate towards camera direction
        Vector3 direction = ball.position - transform.position;

        // transform.rotation *= Quaternion.Euler(0, 90, 0);
        Quaternion rotToBall = Quaternion.LookRotation(direction);

        Quaternion tagetRotation = Quaternion.Euler(0, rotToBall.eulerAngles.y, 0);
        transform.rotation = Quaternion.Lerp(transform.rotation, tagetRotation, _characterStats.RotationSpeed);

        ShootRight();
    }

    private void ShootRight() {
        if (rightGunCdTimer > 0) {
            rightGunCdTimer -= Time.deltaTime;
            return;
        }

        EventsManager.instance.EventShoot(_currentGun.Stats.ShootAudioClip);
        _currentGun.Shoot(ball.position);
        rightGunCdTimer = rightGunCd;
    }

    #region IFREEZABLE
    public void Freeze() {
        _freezed = true;
        freezeTimer = freezeCd;
    }

    public void UnFreeze() {
        _freezed = false;
    }
    #endregion
}
