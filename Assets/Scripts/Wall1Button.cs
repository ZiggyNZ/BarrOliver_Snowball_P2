using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall1Button : MonoBehaviour {

	void Start () {}
	
	void OnCollisionEnter(Collision col) {
		var gameObjects = GameObject.FindGameObjectsWithTag("DestructableWall1");
		for(var i = 0; i < 4; i++) {
			Destroy(gameObjects[i]);
		}
	}
}
