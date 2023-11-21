using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimationController : MonoBehaviour
{
    private Animator _animator;
    private float _velocityZ = 0.0f;
    private float _velocityX = 0.0f;
    [SerializeField] private float _acceleration = 2.0f;
    [SerializeField] private float _deceleration = 2.0f;

    //increase performance
    int _velocityZHash;
    int _velocityXHash;

    void Start()
    {
        _animator = GetComponent<Animator>();

        _velocityXHash = Animator.StringToHash("velocity_x");
        _velocityZHash = Animator.StringToHash("velocity_z");
    }

    void ChangeVelocity(bool forwardPressed, bool leftPressed, bool rightPressed, bool backPressed)
    {
        // forward acceleration
        if (forwardPressed && _velocityZ < 0.5f)
        {
            _velocityZ = 0.5f;
        }
        // back acceleration
        if (backPressed && _velocityZ > -0.5f)
        {
            _velocityZ = -0.5f;
        }
        // left acceleration
        if (leftPressed && _velocityX > -0.5f)
        {
            _velocityX = -0.5f;
        }
        // right acceleration
        if (rightPressed && _velocityX < 0.5f)
        {
            _velocityX = 0.5f;
        }
    }

    void ResetVelocity(bool forwardPressed, bool leftPressed, bool rightPressed, bool backPressed)
    {
        // X-axis reset
        if (!leftPressed && !rightPressed && _velocityX != 0.0f && (_velocityX > -0.05f && _velocityX < 0.05f))
        {
            _velocityX = 0.0f;
        }
        // Z-axis reset
        if (!forwardPressed && !backPressed && _velocityZ != 0.0f && (_velocityZ > -0.05f && _velocityZ < 0.05f))
        {
            _velocityZ = 0.0f;
        }
    }

    // Update is called once per frame
    void Update()
    {
        bool forwardPressed = Input.GetKey(KeyCode.W);
        bool backPressed = Input.GetKey(KeyCode.S);
        bool leftPressed = Input.GetKey(KeyCode.A);
        bool rightPressed = Input.GetKey(KeyCode.D);

        ChangeVelocity(forwardPressed, leftPressed, rightPressed, backPressed);
        ResetVelocity(forwardPressed, leftPressed, rightPressed, backPressed);

        _animator.SetFloat(_velocityXHash, _velocityX);
        _animator.SetFloat(_velocityZHash, _velocityZ);
    }
}
