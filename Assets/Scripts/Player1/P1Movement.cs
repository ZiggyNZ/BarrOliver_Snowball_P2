using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P1Movement : MonoBehaviour {
	private float moveForce = 7;
	private Rigidbody body;

	void Start() {
		body = GetComponent<Rigidbody>();
	}
	
	void Update() {
		float xForce = 0f;
		float zForce = 0f;

		if(Input.GetKey(KeyCode.W)) {
			zForce += moveForce;
			xForce -= moveForce;
		}
		if(Input.GetKey(KeyCode.S)) {
			zForce -= moveForce;
			xForce += moveForce;
		}
		if(Input.GetKey(KeyCode.D)) {
			xForce += moveForce;
			zForce += moveForce;
		}
		if(Input.GetKey(KeyCode.A)) {
			xForce -= moveForce;
			zForce -= moveForce;
		}
		Vector3 force = new Vector3(xForce, 0.0f, zForce);
		body.AddForce(force);

		//TODO slow ball down so it everntually stops rolling
		if(xForce == 0 && zForce == 0) {
			if(body.velocity.magnitude > 0) {
				var friction = body.velocity.magnitude - 0.05f;
				if(friction < 0) {
					friction = 0;
				}
				body.velocity = body.velocity.normalized * friction;
			}
		}
	}
}
