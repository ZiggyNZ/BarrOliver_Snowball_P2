using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dash : MonoBehaviour {

	private float delay = 0.5f;
	private int taps = 0;
	private float dashForce = 600;
	private float liftForce = 50;
	private KeyCode prevKey = KeyCode.I; //Random starter key so it shouldn't affect the program
	private Rigidbody body;

	// Use this for initialization
	void Start () {
		body = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {//Input.GetKeyUp()
		if(Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.A) ||Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.D)) {
			if(!Input.GetKeyUp(prevKey)) {
				taps = 1;
				delay = 0.5f;
				if(Input.GetKeyUp(KeyCode.W)) {
					prevKey = KeyCode.W;
				} else if(Input.GetKeyUp(KeyCode.A)) {
					prevKey = KeyCode.A;
				} else if(Input.GetKeyUp(KeyCode.S)) {
					prevKey = KeyCode.S;
				} else if(Input.GetKeyUp(KeyCode.D)) {
					prevKey = KeyCode.D;
				}
			} else {
				if(delay < 0) {
					taps = 0;
					delay = 0.5f;
				} else if(taps == 1) {
					Vector3 movement = new Vector3(0.0f, liftForce, 0.0f);
					if(prevKey == KeyCode.W) {
						movement = new Vector3(0.0f, liftForce, dashForce);
					} else if(prevKey == KeyCode.A) {
						movement = new Vector3(-dashForce, liftForce, 0.0f);
					} else if(prevKey == KeyCode.S) {
						movement = new Vector3(0.0f, 0.0f, -dashForce);
					} else if(prevKey == KeyCode.D) {
						movement = new Vector3(dashForce, liftForce, 0.0f);
					}
					body.AddForce(movement);
					taps = 0;
					delay = 0.5f;
					prevKey = KeyCode.I;
				}
			}
		}
		delay -= Time.deltaTime;
	}
}
