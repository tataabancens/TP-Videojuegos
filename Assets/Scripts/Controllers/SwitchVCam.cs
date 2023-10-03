using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Cinemachine;

public class SwitchVCam : MonoBehaviour
{
    [SerializeField] private PlayerInput _playerInput;

    private InputAction _aimAction;
	private CinemachineVirtualCamera _virtualCamera;
	private int _priorityBoostAmount = 10;
	[SerializeField] Canvas thirdPersonCanvas;
	[SerializeField] Canvas aimCanvas;

	private void Awake() {
		_virtualCamera = GetComponent<CinemachineVirtualCamera>();
		_aimAction = _playerInput.actions["Aim"];
	}

	private void OnEnable() {
		_aimAction.performed += _ => StartAim();
		_aimAction.canceled += _ => CancelAim();
	}

	private void OnDisable() {
		_aimAction.performed -= _ => StartAim();
		_aimAction.canceled -= _ => CancelAim();
	}

	private void StartAim() {
		_virtualCamera.Priority += _priorityBoostAmount;
		aimCanvas.enabled = true;
		thirdPersonCanvas.enabled = false;
	}

	private void CancelAim() {
		_virtualCamera.Priority -= _priorityBoostAmount;
		aimCanvas.enabled = false;
		thirdPersonCanvas.enabled = true;
	}
}
