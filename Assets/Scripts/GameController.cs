using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class GameController : MonoBehaviour {

	private enum GameState { init, started, gameover, restart }

	[SerializeField] private GameObject PlayerPrefab;
	[SerializeField] private GameObject ChestPrefab;
	[SerializeField] private Vector2 PlayerSpawnPosition;
	private GameState _gameState;
	private Player _player;


	private void Awake() {
		_gameState = GameState.init;
	}

	private void Init() {
		 var playerObject = Instantiate(PlayerPrefab);
		playerObject.transform.localPosition = PlayerSpawnPosition;
		_player = playerObject.GetComponent<Player>();
		_player.SetController(this);
		_gameState = GameState.started;
	}

	private void Update() {
		switch (_gameState) {
			case GameState.init:
				Init();
				break;

			case GameState.gameover:
				Debug.Log("GameOver");
				EditorApplication.isPlaying = false;
				break;
		}
	}

	public void Damage() {
		_gameState = GameState.gameover;
	}
}
