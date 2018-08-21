using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour {

	private float jumpForce = 300;
	private bool grounded = true;
	private Rigidbody body;

	// Use this for initialization
	void Start () {
		body = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
		//Jump with Spacebar
		if(Input.GetKeyDown(KeyCode.Space) && grounded) {
			Vector3 jump = new Vector3(0.0f, jumpForce, 0.0f);
			body.AddForce(jump);
			grounded = false;
		}
	}
	void OnCollisionEnter(Collision other) {
		if(other.gameObject.tag == "Ground") {
        	grounded = true;
     	}
	}
}
