﻿using System;
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BallScript : MonoBehaviour {
	private Rigidbody rigid;
	private Vector3 lastVelocity;

	private WhiteBall whiteBall;

	public bool stopped = true;

	// Initial balls positions X, Z in ball number order
	private float minHeight = 10;
	private float maxHeight = 14.15235f;

	// Use this for initialization
	private TurnManager tm;

	public bool holed;

	private Text BallInfo;

	public int BallNumber;

	void Start() {
		rigid = GetComponent<Rigidbody>();
		tm = GameObject.Find("TurnManager").GetComponent<TurnManager>();
		BallInfo = GameObject.Find("BallInfo").GetComponent<Text>();
		BallInfo.text = "";
		holed = false;
	}

	// Update is called once per frame

	void Update() {

		if (transform.position.y <= minHeight) {
			rigid.velocity = new Vector3(0, 0, 0);
		}
		else if (transform.position.y > maxHeight) {
			transform.position = new Vector3(transform.position.x, maxHeight, transform.position.z);
		}

		lastVelocity = rigid.velocity;
		if (rigid.velocity.magnitude <= 0.8f && rigid.velocity.magnitude > 0.0001f) {
			//print(rigid.velocity.magnitude);
			if (!stopped) {
				stopped = true;
			}

			rigid.velocity = new Vector3(0, 0, 0);
			if (CompareTag("WhiteBall")) {
				//mostrar palo
				//cambiar de turno
//				tm.ChangeTurn();
			}
		}
		else if (rigid.velocity.magnitude >= 20f && lastVelocity.magnitude > 0.8f) {
			rigid.velocity = lastVelocity;
		}
		else if (rigid.velocity.magnitude > 0.01f) {
			stopped = false;
		}
	}

	private void OnTriggerEnter(Collider other) {
//		print(other.tag);
		if (other.CompareTag("Hole")) {
			tm.inBall(tag);
			holed = true;
		}
	}

	private void OnCollisionEnter(Collision other) {
		if (other.gameObject.tag == "HoleWall") {
			rigid.velocity = new Vector3(0, -5, 0);
		}
	}

	void OnMouseOver() {
		if (tag != "WhiteBall") {
			BallInfo.text = "Ball: " + BallNumber + " (" + tag + ")";
		}
	}

	void OnMouseExit() {
		BallInfo.text = "";
	}

	public Boolean isStopped() {
		return stopped || holed;
	}
}
