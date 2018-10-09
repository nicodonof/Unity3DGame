using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ballScript : MonoBehaviour {
	private float t = 0.0f;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		t += Time.deltaTime;
		if (t < 1.0f)
		{
			GetComponent<Rigidbody>().velocity = new Vector3(10, 0, 0);
		}
	}
}
