using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour {
	
	private float _speed = 5f;
	private float _force = 300;
	private float _jumpCooldownTimer = 0f;
	private float _jumpTime = 1f;

	void FixedUpdate () {
		if (_jumpCooldownTimer < _jumpTime)
			_jumpCooldownTimer += Time.fixedUnscaledDeltaTime;

		if (Input.GetKey(KeyCode.RightArrow)) {
			transform.Translate(Vector2.right * _speed * Time.deltaTime);
		}
		if (Input.GetKey(KeyCode.LeftArrow)) {
			transform.Translate(Vector2.left * _speed * Time.deltaTime);
		}

		if (_jumpCooldownTimer > _jumpTime &&Input.GetKeyDown(KeyCode.Space)) {
			gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * _force);
			_jumpCooldownTimer = 0f;
		}
	}
}
