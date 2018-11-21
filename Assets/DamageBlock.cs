using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageBlock : MonoBehaviour {
	
	private BoxCollider2D _collider;
	private GameController _gameController;

	private void Start() {
		_collider = GetComponent<BoxCollider2D>();
		_gameController = FindObjectOfType<GameController>();
		if (_gameController == null) {
			Debug.Log("Controller is null");
			return;
		}
		_gameController.AddToObserver(this);
	}

	public void ToggleCollider(bool isEnable) {
		_collider.enabled = isEnable;
	}
}
