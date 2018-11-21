using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class GameController : MonoBehaviour {

	private enum GameState { init, started, gameover, restart }

	[SerializeField] private CameraController Camera;
	[SerializeField] private GameObject PlayerPrefab;
	[SerializeField] private GameObject ChestPrefab;
	[SerializeField] private Vector2 PlayerSpawnPosition;
	private GameState _gameState;
	private Player _player;
	private Observer observer;
	private int _lives = 3;

	private float _collideChillTimer;
	private float _collideChillTime = 1f;
	private bool _isNeedCollide;


	private void Awake() {
		_gameState = GameState.init;
	}

	private void Init() {
		 var playerObject = Instantiate(PlayerPrefab);
		playerObject.transform.localPosition = PlayerSpawnPosition;
		Camera.SetTarget(playerObject);
		_player = playerObject.GetComponent<Player>();
		_player.SetController(this);
		_gameState = GameState.started;
		observer = new Observer();
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

		if (_isNeedCollide)
			return;
		
		_collideChillTimer += Time.unscaledDeltaTime;

		if (!_isNeedCollide && _collideChillTimer >= _collideChillTime) {
			observer.ToggleColliders(true);
			_isNeedCollide = true;
		}
	}

	public void Damage() {
		_lives--;
		if (_lives <= 0) {
			_gameState = GameState.gameover;
			return;
		}
		DisableTempColliders();
	}

	public void AddToObserver(DamageBlock block) {
		observer.AddToObserver(block);
	}

	private void DisableTempColliders() {
		_collideChillTimer = 0;
		_isNeedCollide = false;
		observer.ToggleColliders(false);
	}
}
