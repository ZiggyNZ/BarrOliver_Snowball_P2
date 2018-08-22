using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour {
	private GameObject player1;
	private Transform player1Respawn;

	private GameObject player2;
	private Transform player2Respawn;

	void Start () {
		this.player1 = GameObject.FindWithTag("Player1");
		this.player1Respawn = GameObject.FindWithTag("P1Respawn").transform;

		this.player2 = GameObject.FindWithTag("Player2");
		this.player2Respawn = GameObject.FindWithTag("P2Respawn").transform;

	}

	void OnCollisionEnter(Collision collision) {
		if(collision.gameObject.tag == "Player1") {
			player1.transform.position = player1Respawn.transform.position;
			player1.GetComponent<Rigidbody>().velocity = new Vector3(0f, 0f, 0f);
		}
		if(collision.gameObject.tag == "Player2") {
			player2.transform.position = player2Respawn.transform.position;
			player2.GetComponent<Rigidbody>().velocity = new Vector3(0f, 0f, 0f);
		}
	}
}
