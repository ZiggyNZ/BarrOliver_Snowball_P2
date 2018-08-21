using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour {
	private Camera camera;
	private Transform p1;
	private Transform p2;

	private int minZoom = 10;

	// Use this for initialization
	void Start () {
		this.camera = GetComponent<Camera>();
		p1 = GameObject.FindWithTag ("Player1").transform;
		p2 = GameObject.FindWithTag ("Player2").transform;
	}
	
	// Update is called once per frame
	void Update () {
		//Calculate camera distance from midpoint of players
		float distance = (p1.position - p2.position).magnitude;
		if(distance < 6f) { //Camera should not zoom any more than this
			distance = 6f;
		}
		//TODO set a max disntance (should be base on level)

		Vector3 midpoint = (p1.position + p2.position) / 2f;
		Vector3 cameraDest = midpoint - camera.transform.forward * distance * 1.5f;

		if(camera.orthographic) {
			camera.orthographicSize = distance;
		}
		camera.transform.position = Vector3.Slerp(camera.transform.position, cameraDest, 0.8f);
		if ((cameraDest - camera.transform.position).magnitude <= 0.05f) {
			camera.transform.position = cameraDest;
		} 
	}
}
