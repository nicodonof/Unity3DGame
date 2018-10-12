using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestMove : MonoBehaviour {
	private Camera cam;
	private RaycastHit hit;
	private Ray ray;
	private GameObject whiteBall;
	private TurnManager tm;

	private Boolean mouseDown = false;
	private float mouseDownTimer = 0;

	private float maxMouseDownTimer = 1.3f;

	// Use this for initialization
	void Start () {
		whiteBall = GameObject.FindGameObjectWithTag("WhiteBall");
		cam = Camera.main.GetComponent<Camera>();
		tm = GameObject.Find("TurnManager").GetComponent<TurnManager>();

	}

	// Update is called once per frame
	void Update () {
		Vector3 mousep = Input.mousePosition;
		Vector3 ballPos = Camera.main.WorldToScreenPoint(whiteBall.transform.position);

		float angle = - Mathf.Atan2(mousep.x - ballPos.x, mousep.y - ballPos.y) ;

		transform.eulerAngles = new Vector3(90f, 180f, angle * Mathf.Rad2Deg);
		if (Input.GetMouseButtonDown(0)) {
			mouseDownTimer = 0;
			mouseDown = true;
		}else if(Input.GetMouseButtonDown(1)) {
			mouseDownTimer = 0;
			mouseDown = false;
		}else if(Input.GetMouseButtonUp(0) && mouseDown){
			Vector3 dir = new Vector3(whiteBall.transform.position.x - transform.position.x, 0f, whiteBall.transform.position.z - transform.position.z);
			whiteBall.GetComponent<Rigidbody>().AddForce(dir*mouseDownTimer*100);
			BallScript ballScript = whiteBall.GetComponent<BallScript>();
			whiteBall.transform.position = new Vector3(whiteBall.transform.position.x, ((Vector3)BallScript.InitBallPositions[ballScript.BallNumber]).y, whiteBall.transform.position.z);
			tm.Changed = false;
			mouseDownTimer = 0;
			mouseDown = false;
		}else if(mouseDown){
			if(mouseDownTimer >= maxMouseDownTimer){
				mouseDownTimer = maxMouseDownTimer;
			}else{
				mouseDownTimer += Time.deltaTime;
			}
		}
		float radius = 28f;
		if(mouseDownTimer != 0){
 			radius += radius * mouseDownTimer/maxMouseDownTimer * 0.2f;
		}
		float newZ = whiteBall.transform.position.z + radius * Mathf.Cos(angle);
		float newX = whiteBall.transform.position.x + radius * -Mathf.Sin(angle);
		transform.position = new Vector3(newX, 14.4f, newZ);
	}

}
