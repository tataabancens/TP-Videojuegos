using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class GoalKeeper : MonoBehaviour, IFreezable
{
    [SerializeField] private Transform ball;
    private CharacterController _controller;
    [SerializeField] private CharacterStats _characterStats;
    [SerializeField] private float _minMistanceToBall = 2.5f;
    [SerializeField] private float _maxDistanceFromStart = 10f;
    private Vector3 _startPosition;
    private bool _freezed;

    void Start()
    {
        _controller = GetComponent<CharacterController>();
        _startPosition = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        _freezed = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (_freezed) return;

        Vector3 ballDistance = ball.position - transform.position;
        Vector3 distanceFromStartVec = _startPosition - transform.position;
        float distanceFromStart = distanceFromStartVec.magnitude;
        float moveAmount = Time.deltaTime * _characterStats.MovementSpeed;
        if (distanceFromStart + moveAmount > _maxDistanceFromStart) {
            Vector3 direction = new Vector3(distanceFromStartVec.x, 0, distanceFromStartVec.z);
            EventQueueManager.instance.AddCommand(new CmdMove(_controller, direction.normalized * moveAmount));
        };


        if (ballDistance.magnitude > _minMistanceToBall) {
            Vector3 direction = new Vector3(ballDistance.x, 0, ballDistance.z);
            EventQueueManager.instance.AddCommand(new CmdMove(_controller, direction.normalized * moveAmount));
        }
    }

    #region IFREEZABLE
    public void Freeze() {
        _freezed = true;
    }

    public void UnFreeze() {
        _freezed = false;
    }
    #endregion
}
