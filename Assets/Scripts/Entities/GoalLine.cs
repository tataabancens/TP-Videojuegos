using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalLine : MonoBehaviour
{
    private Collider _collider;
    [SerializeField] private AudioSource _goalAnounce;
    [SerializeField] private AudioSource _ballDestroyVFX;
    // Start is called before the first frame update
    void Start()
    {
        _collider = GetComponent<Collider>();
    }

	private void OnTriggerEnter(Collider other) {
		if (other.CompareTag("Pelota")) {
            EventsManager.instance.EventGoal(1);
            _ballDestroyVFX.Play();
            _goalAnounce.Play();
            Ball ball = other.gameObject.GetComponent<Ball>();
            ball.RespawnBall();
		}
	}

	// Update is called once per frame
	void Update()
    {
        
    }
}
