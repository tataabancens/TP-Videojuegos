using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour, IFreezable
{
    private Rigidbody _rigidbody;
    [SerializeField] private ParticleSystem _destructionVFX;
    [SerializeField] private AudioSource _goalExplosion;
    private Vector3 _initialPosition;

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _initialPosition = new Vector3(transform.position.x, transform.position.y, transform.position.z);
    }

	#region IFREEZABLE
	public void Freeze() {
        _rigidbody.angularVelocity = new Vector3(0, 0, 0);
        _rigidbody.velocity = new Vector3(0, 0, 0);

        _rigidbody.useGravity = false;
    }

    public void UnFreeze() {
        _rigidbody.useGravity = true;
    }
	#endregion

	public void RespawnBall() {
        Freeze();
        UnFreeze();
        if (_destructionVFX != null)
        {
            ParticleSystem vfxInstance = Instantiate(_destructionVFX, transform.position, Quaternion.identity);
            vfxInstance.Play();
            if (_goalExplosion != null)
            {
                _goalExplosion.Play();
            }
            Destroy(vfxInstance.gameObject, vfxInstance.main.duration);
        }
        transform.position = _initialPosition;
	}
}
