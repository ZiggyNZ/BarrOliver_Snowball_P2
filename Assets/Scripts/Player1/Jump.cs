using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour {
	private float jumpForce = 300;
	private float highJumpForce = 20;
	private bool highJump = false;

	private Rigidbody body;
	private Transform transform;

	void Start () {
		body = GetComponent<Rigidbody>();
		this.transform = GameObject.FindWithTag("Player1").transform;
	}
	void Update () {
		if(Input.GetKeyDown(KeyCode.Space) && isGrounded()) {
			Vector3 jump = new Vector3(0.0f, jumpForce, 0.0f);
			body.AddForce(jump);
			highJump = true;
		} else if(highJumpForce <= 0) {
			highJump = false;
			highJumpForce = 20;
		} else if(Input.GetKey(KeyCode.Space) && highJump) {
			Vector3 lift = new Vector3(0.0f, highJumpForce, 0.0f);
			body.AddForce(lift);
			highJumpForce -= 1;
		} else if(Input.GetKeyUp(KeyCode.Space)) {
			highJump = false;
		}
	}
	bool isGrounded() {
		return Physics.Raycast(transform.position, -Vector3.up, 0.6f); //0.4 min
	}
}
