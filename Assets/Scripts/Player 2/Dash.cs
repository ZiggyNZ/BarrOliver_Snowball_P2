using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dash : MonoBehaviour {
	private float dashForce = 400f;
	private float liftForce = 50f;

	private Rigidbody body;
	private Transform transform;

	void Start () {
		body = GetComponent<Rigidbody>();
		this.transform = GameObject.FindWithTag("Player2").transform;
	}
	
	void Update () {
		if(Input.GetKeyDown(KeyCode.Return) && isGrounded()) {
			float xForce = 0f;
			float zForce = 0f;
			if(Input.GetKey(KeyCode.I)) {
				zForce += dashForce;
				xForce += dashForce;
			} else if(Input.GetKey(KeyCode.K)) {
				zForce -= dashForce;
				xForce -= dashForce;
			}
			if(Input.GetKey(KeyCode.L)) {
				zForce -= dashForce;
				xForce += dashForce;
			} else if(Input.GetKey(KeyCode.J)) {
				zForce += dashForce;
				xForce -= dashForce;
			}
			Vector3 force = new Vector3(xForce, liftForce, zForce);
			body.AddForce(force);
		}
	}
	bool isGrounded() {
		return Physics.Raycast(transform.position, -Vector3.up, 0.6f); //0.4 min
	}
}
