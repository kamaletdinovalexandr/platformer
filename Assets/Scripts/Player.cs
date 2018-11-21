using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	[SerializeField] private GameController GameController;

	public void SetController(GameController controller) {
		GameController = controller;
	}

	void OnTriggerEnter2D(Collider2D col) {
		if (GameController != null)
			GameController.Damage();
	}
}
