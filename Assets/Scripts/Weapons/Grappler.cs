using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grappler : Gun
{
	[SerializeField] private LayerMask whatIsGrappable;
	[SerializeField] private LineRenderer lr;
	[SerializeField] private Character character;

	[Header("Grappler")]
	[SerializeField] private float grappleDelayTime;
	[SerializeField] private float overShootYAxis;
	private Vector3 grapplePoint;

	[Header("Cooldown")]
	[SerializeField] private float grappleCd;
	[SerializeField] private float grappleCdTimer;

	private bool grappling;

	private void Update() {
		if (grappleCdTimer > 0) grappleCdTimer -= Time.deltaTime;
	}

	private void LateUpdate() {
		if (grappling) lr.SetPosition(0, AttackPoint.position);
	}

	public override void Shoot()
	{
		if (!grappling) {
			StartGrapple();
		} else {
			ExecuteGrapple();
		}
	}

	private void StartGrapple() {
		if (grappleCdTimer > 0) return;

		grappling = true;

		RaycastHit hit;
		if (Physics.Raycast(_cameraTransform.position, _cameraTransform.forward, out hit, _bulletHitMissDistance, whatIsGrappable)) {
			grapplePoint = hit.point;

		} else {
			grapplePoint = _cameraTransform.position + _cameraTransform.forward * _bulletHitMissDistance;
			Invoke(nameof(StopGrapple), grappleDelayTime);
		}

		lr.enabled = true;
		lr.SetPosition(1, grapplePoint);
	}

	private void ExecuteGrapple() {
		Vector3 lowestPoint = new Vector3(transform.position.x, transform.position.y - 1f, transform.position.z);

		float grapplePointRelativeYPos = grapplePoint.y - lowestPoint.y;
		float highestPointOnArc = grapplePointRelativeYPos + overShootYAxis;

		if (grapplePointRelativeYPos < 0) highestPointOnArc = overShootYAxis;
		character.JumpToPosition(grapplePoint, highestPointOnArc);

		Invoke(nameof(StopGrapple), 1f);
	}

	private void StopGrapple() {
		grappling = false;

		grappleCdTimer = grappleCd;

		lr.enabled = false;
	}
}
