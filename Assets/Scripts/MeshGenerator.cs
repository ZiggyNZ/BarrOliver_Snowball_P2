using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeshGenerator : MonoBehaviour {

	void Start () {
		GameObject map = GameObject.Find("Map");
		MeshFilter[] filters = map.GetComponentsInChildren<MeshFilter>();
		foreach(MeshFilter filter in filters) {
			var collider = filter.gameObject.AddComponent<MeshCollider>();
			collider.sharedMesh = filter.mesh;
		}
	}
}
