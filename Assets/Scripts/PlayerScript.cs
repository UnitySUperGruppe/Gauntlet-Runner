using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour {

	public float StrafeSpeed = 4f;

	private GameControlScript _gameControlScript;
	private Animator _animator;
	private bool _jumping;

	private void Start() {
		_gameControlScript = FindObjectOfType<GameControlScript>();
		_animator = GetComponent<Animator>();
	}

	private void Update() {
		float xMove = Input.GetAxis("Horizontal") * Time.deltaTime * StrafeSpeed;
		transform.Translate(xMove, 0f, 0f);
		if(transform.position.x > 4) {
			transform.Translate(4f - transform.position.x, 0f, 0f);
		} else if(transform.position.x < -4) {
			transform.Translate(-4f - transform.position.x, 0f, 0f);
		}

		if (Input.GetButtonDown("Jump")) {
			_animator.SetTrigger("Jump");
		}

		if (_animator.GetCurrentAnimatorStateInfo(0).IsName("Run")) {
			_jumping = false;
		} else {
			_jumping = true;
		}
	}

	void OnTriggerEnter(Collider other) {
		if (other.gameObject.name == "Powerup(Clone)") {
			_gameControlScript.PowerUpCollected();
		} else if (other.gameObject.name == "Obstacle(Clone)" && !_jumping) {
			_gameControlScript.SlowWorldDown();
		}
		Destroy(other.gameObject);	
	}
}
