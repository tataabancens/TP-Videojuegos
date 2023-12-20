using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimationController : MonoBehaviour
{
    private Animator _animator;
    private Vector3 previousPosition;
    private float _velocityZ = 0.0f;
    private float _velocityX = 0.0f;
    private float _velocityY = 0.0f;
    private bool _isJumping = false;
    private bool _isGrounded = true;
    [SerializeField] private float _acceleration = 2.0f;
    [SerializeField] private float _deceleration = 2.0f;

    //increase performance
    int _velocityZHash;
    int _velocityXHash;
    int _velocityYHash;
    int _jumpingHash;
    int _groundedHash;

    void Start()
    {
        _animator = GetComponent<Animator>();
        previousPosition = transform.position;

        _velocityXHash = Animator.StringToHash("velocity_x");
        _velocityZHash = Animator.StringToHash("velocity_z");
        _velocityYHash = Animator.StringToHash("velocity_y");
        _jumpingHash = Animator.StringToHash("isJumping");
        _groundedHash = Animator.StringToHash("isGrounded");
    }

    void ChangeVelocity(bool forwardPressed, bool leftPressed, bool rightPressed, bool backPressed, bool jumpPressed)
    {
        // forward acceleration
        if (forwardPressed && _velocityZ < 1f)
        {
            _velocityZ = 0.5f;
        }
        // back acceleration
        if (backPressed && _velocityZ > -1f)
        {
            _velocityZ = -0.5f;
        }
        // left acceleration
        if (leftPressed && _velocityX > -1f)
        {
            _velocityX = -0.5f;
        }
        // right acceleration
        if (rightPressed && _velocityX < 1f)
        {
            _velocityX = 0.5f;
        }
    }

    void ResetVelocity(bool forwardPressed, bool leftPressed, bool rightPressed, bool backPressed, bool jumpPressed)
    {
        // X-axis reset
        if (!leftPressed && !rightPressed && _velocityX != 0.0f && (_velocityX > -1f && _velocityX < 1f))
        {
            _velocityX = 0.0f;
        }
        // Z-axis reset
        if (!forwardPressed && !backPressed && _velocityZ != 0.0f && (_velocityZ > -1f && _velocityZ < 1f))
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
        bool jumpPressed = Input.GetKey(KeyCode.Space);

        ChangeVelocity(forwardPressed, leftPressed, rightPressed, backPressed, jumpPressed);
        ResetVelocity(forwardPressed, leftPressed, rightPressed, backPressed, jumpPressed);

        _animator.SetFloat(_velocityXHash, _velocityX);
        _animator.SetFloat(_velocityZHash, _velocityZ);
    }

    void FixedUpdate()
    {

        float YAxisVelocity = (transform.position.y - previousPosition.y) / Time.deltaTime;
        // Update the previous position
        previousPosition = transform.position;

        bool jumpPressed = Input.GetKey(KeyCode.Space);

        if (jumpPressed)
        {
            _isJumping = true;
            _isGrounded = false;
        }
        if (YAxisVelocity > 0 && _isJumping)
        {
            _velocityY = 1.0f;
        }
        else if (YAxisVelocity < -0.2f && _isJumping)
        {
            _velocityY = -1.0f;
        }
        else if(YAxisVelocity < 0.1f && YAxisVelocity > -0.1f && _isJumping)
        {
            _velocityY = 0.0f;
            _isGrounded = true;
            _isJumping = false;
        }
        _animator.SetFloat(_velocityYHash, _velocityY);
        _animator.SetBool(_jumpingHash, _isJumping);
        _animator.SetBool(_groundedHash, _isGrounded);
    }
}
