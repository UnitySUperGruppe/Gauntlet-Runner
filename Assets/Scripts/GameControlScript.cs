using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameControlScript : MonoBehaviour {

	public float ScrollSpeed = 25f;
	public float TimeExstension = 1.5f;
	public MoveGroundScript MoveGroundScript;
	public Text TimeRemainingText;

	private float _timeRemaining = 10;
	private float _totalTimeElapsed;
	private bool _gameIsOver = false;

	public void PowerUpCollected() {
		_timeRemaining += TimeExstension;
	}

	public void SlowWorldDown() {
		CancelInvoke("RestoreWorldSpeed");
		Invoke("RestoreWorldSpeed", 1);
		Time.timeScale = 0.5f;
	}

	void RestoreWorldSpeed() {
		Time.timeScale = 1f;
	}

	void Update() {
		if (_gameIsOver) {
			return;
		}
		_totalTimeElapsed += Time.deltaTime;
		_timeRemaining -= Time.unscaledDeltaTime;
		if (_timeRemaining <= 0) {
			_gameIsOver = true;
		}

		TimeRemainingText.text = ("Time Remaining: ") + _timeRemaining.ToString();
	}

	
}