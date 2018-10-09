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
		print(mousep);
		print(ballPos);
//		temp.z = 7.35f; // Set this to be the distance you want the object to be placed in front of the camera.
		float difx = mousep.x - ballPos.x;
		float dify = mousep.y - ballPos.y;
		
		float angle = - Mathf.Atan2(mousep.x - ballPos.x, mousep.y - ballPos.y) ;

		transform.eulerAngles = new Vector3(90f, 0f, angle * Mathf.Rad2Deg);
//		transform.position = Camera.main.ScreenToViewportPoint(mousep);
//		ray = Camera.main.ScreenPointToRay(mousep);
//  
//		if (Physics.Raycast(ray, out hit)) {
//			transform.position = hit.point;
//		}

		float radius = 2.5f;
		float newZ = whiteBall.transform.position.z + radius * Mathf.Cos(angle);
		float newX = whiteBall.transform.position.x + radius * -Mathf.Sin(angle);
		transform.position = new Vector3(newX, 0f, newZ);
		if (Input.GetMouseButtonDown(0)) {
			Vector3 dir = whiteBall.transform.position - transform.position;
			whiteBall.GetComponent<Rigidbody>().AddForce(dir*1000f);
		}
	}
	
}
