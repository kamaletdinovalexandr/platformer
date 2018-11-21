using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

	GameObject _target;

	public void SetTarget(GameObject player) {
		_target = player; 
	}

	void Update () {
		if (_target == null)
			return;
		UpdatePosition();
	}

	private void UpdatePosition() {
		var newCameraPosition = transform.position;
		newCameraPosition.x = _target.transform.position.x;
		transform.position = newCameraPosition;
	}
}
