using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ballScript : MonoBehaviour {
	private float t = 0.0f;

	// Use this for initialization
	void Start () {
		GetComponent<Rigidbody>().AddForce(Vector3.forward * 1000);
	}

	// Update is called once per frame
	void Update () {
	}
}
