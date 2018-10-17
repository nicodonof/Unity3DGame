﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestMove : MonoBehaviour {
	private const float MinForce = 0.050f;

	private Camera cam;
	private GameObject whiteBall;
	private TurnManager tm;
	private BallManager bm;

	private AudioSource TacoBallHit;

	private Boolean mouseDown;
	private float mouseDownTimer;

	private float maxMouseDownTimer = 1.3f;

	public bool show = true;
	// Use this for initialization
	void Start () {
		TacoBallHit = GameObject.Find("TacoBallHit").GetComponent<AudioSource>();
		TacoBallHit.velocityUpdateMode = AudioVelocityUpdateMode.Dynamic;
		whiteBall = GameObject.FindGameObjectWithTag("WhiteBall");
		cam = Camera.main.GetComponent<Camera>();
		tm = GameObject.Find("TurnManager").GetComponent<TurnManager>();
		bm = GameObject.Find("BallManager").GetComponent<BallManager>();
	}

	// Update is called once per frame
	void Update () {
		if(Math.Abs(Time.timeScale) < 0.001f || Time.timeScale == 0){
			return;
		}
		if (show) {

			Vector3 mousep = Input.mousePosition;
			Vector3 ballPos = cam.WorldToScreenPoint(whiteBall.transform.position);

			float angle = -Mathf.Atan2(mousep.x - ballPos.x, mousep.y - ballPos.y);

			transform.eulerAngles = new Vector3(90f, 180f, angle * Mathf.Rad2Deg);
			if (Input.GetMouseButtonDown(0)) {
				mouseDownTimer = MinForce;
				mouseDown = true;
			} else if (Input.GetMouseButtonDown(1)) {
				mouseDownTimer = 0;
				mouseDown = false;
			} else if (Input.GetMouseButtonUp(0) && mouseDown) {
				Vector3 dir = new Vector3(whiteBall.transform.position.x - transform.position.x, 0f,
					whiteBall.transform.position.z - transform.position.z);
				TacoBallHit.volume = 0.7f * (mouseDownTimer / maxMouseDownTimer);
				TacoBallHit.Play(0);
				whiteBall.GetComponent<Rigidbody>().AddForce(dir * mouseDownTimer * 100);
				whiteBall.GetComponent<BallScript>().stopped = false;
				tm.Changed = false;
				show = false;
				mouseDownTimer = 0;
				mouseDown = false;
			} else if (mouseDown) {
				if (mouseDownTimer >= maxMouseDownTimer) {
					mouseDownTimer = maxMouseDownTimer;
				}
				else {
					mouseDownTimer += Time.deltaTime;
				}
			}

			float radius = 28f;
			if (Math.Abs(mouseDownTimer) > 0.001f) {
				radius += radius * mouseDownTimer / maxMouseDownTimer * 0.2f;
			}

			float newZ = whiteBall.transform.position.z + radius * Mathf.Cos(angle);
			float newX = whiteBall.transform.position.x + radius * -Mathf.Sin(angle);
			transform.position = new Vector3(newX, 14.4f, newZ);
			if (!show) {
				transform.position = new Vector3(newX, 100f, newZ);
			}
		}
	}

}
