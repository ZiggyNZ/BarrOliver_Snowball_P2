using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeshGenerator : MonoBehaviour {

	void Start () {
		GameObject map = GameObject.Find("Map");
		MeshFilter[] _filters = map.GetComponentsInChildren<MeshFilter>();
		foreach(MeshFilter _filter in _filters) {
			var collider = _filter.gameObject.AddComponent<MeshCollider>();
			collider.sharedMesh = _filter.mesh;
		}
	}
	
	void Update () {}
}
