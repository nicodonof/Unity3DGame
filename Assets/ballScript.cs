using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ballScript : MonoBehaviour {
	private Rigidbody rigid;
	private Vector3 lastVelocity;

	// Use this for initialization
	void Start () {
		rigid = GetComponent<Rigidbody>();
	}

	// Update is called once per frame
	void Update () {
		print(rigid.velocity.magnitude);
		lastVelocity = rigid.velocity;
		if(rigid.velocity.magnitude <= 0.8f){
			rigid.velocity = new Vector3(0,0,0);
		}else if(rigid.velocity.magnitude >= 20f && lastVelocity.magnitude > 0.8f){
			rigid.velocity = lastVelocity;
		}
	}
}
