using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestMove : MonoBehaviour {

	// Use this for initialization
	void Start () {
		GetComponent<Rigidbody>().velocity = new Vector3(-5,0,5);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
