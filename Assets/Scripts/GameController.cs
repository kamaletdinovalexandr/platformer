using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

	private enum GameState { started, gameOver }

	[SerializeField] private GameObject PlayerPrefab;
	[SerializeField] private GameObject ChestPrefab;
	[SerializeField] private Vector2 PlayerSpawnPosition;
	private GameState _gameState;
	private GameObject _playerObject;

	private void Start() {
		_playerObject = Instantiate(PlayerPrefab);
		_playerObject.transform.localPosition = PlayerSpawnPosition;
	}

}
