using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

	private float moveSpeed = 10;
	private Rigidbody body;

	// Use this for initialization
	void Start() {
		body = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update() {
		//Move l/r/u/d
		float horizontal = Input.GetAxis("Horizontal");
		float vertical = Input.GetAxis("Vertical");
		Vector3 movement = new Vector3(horizontal, 0.0f, vertical);
		body.AddForce(movement * moveSpeed);

		//TODO slow ball down so it everntually stops rolling
	}
}
