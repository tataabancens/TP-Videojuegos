using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutOfBounds : MonoBehaviour
{
    private Collider _collider;
	[SerializeField] private LayerMask _hittableMask;
	void Start()
    {
        _collider = GetComponent<Collider>();
    }

	private void OnTriggerEnter(Collider other) {
		if (((1 << other.gameObject.layer) & _hittableMask) != 0) {
			if (other.CompareTag("Pelota")) {
				Ball ball = other.GetComponent<Ball>();
				ball.RespawnBall();
			}
		}
	}
}
