using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObjectScript : MonoBehaviour {

	private GameControlScript _gameControlScript;

	// Use this for initialization
	void Start () {
		_gameControlScript = FindObjectOfType<GameControlScript>();
	}
	
	// Update is called once per frame
	void Update () {
		float offset = _gameControlScript.ScrollSpeed * Time.deltaTime;
		transform.Translate(0f, 0f, -offset);
	}
}
