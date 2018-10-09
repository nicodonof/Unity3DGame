using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestMove : MonoBehaviour {
	private Camera cam;
	private RaycastHit hit;
	private Ray ray;
	private GameObject whiteBall;

	// Use this for initialization
	void Start () {
		whiteBall = GameObject.FindGameObjectWithTag("WhiteBall");
		cam = Camera.main.GetComponent<Camera>();
//		GetComponent<Rigidbody>().velocity = new Vector3(-5,0,5);
	}

	// Update is called once per frame
	void Update () {
		Vector3 mousep = Input.mousePosition;
		Vector3 ballPos = Camera.main.WorldToScreenPoint(whiteBall.transform.position);

		float angle = - Mathf.Atan2(mousep.x - ballPos.x, mousep.y - ballPos.y) ;

		transform.eulerAngles = new Vector3(90f, 180f, angle * Mathf.Rad2Deg);

		float radius = 28f;
		float newZ = whiteBall.transform.position.z + radius * Mathf.Cos(angle);
		float newX = whiteBall.transform.position.x + radius * -Mathf.Sin(angle);
		transform.position = new Vector3(newX, 14.4f, newZ);
		if (Input.GetMouseButtonDown(0)) {
			Vector3 dir = new Vector3(whiteBall.transform.position.x - transform.position.x, 0f, whiteBall.transform.position.z - transform.position.z);
			whiteBall.GetComponent<Rigidbody>().AddForce(dir*100f);
		}
	}

}
