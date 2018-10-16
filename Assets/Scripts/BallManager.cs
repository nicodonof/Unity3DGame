using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class BallManager : MonoBehaviour {
	public static List<Vector3> InitBallPositions = new List<Vector3> {
		new Vector3(12, 14.16f, 0), //WhiteBall
		new Vector3(-11.7f, 14.16f,-1), //Ball 1
		new Vector3(-13.5f, 14.16f, 1), //Ball 2
		new Vector3(-12.6f, 14.16f, -0.51f), //Ball 3
		new Vector3(-13.5f, 14.16f, -1), //Ball 4
		new Vector3(-13.5f, 14.16f, -2), //Ball 5
		new Vector3(-12.6f, 14.16f, 1.53f), //Ball 6
		new Vector3(-10.9f, 14.16f, 0.51f), //Ball 7
		new Vector3(-11.7f, 14.16f, 0), //Ball 8
		new Vector3(-10, 14.16f, 0), //Ball 9
		new Vector3(-12.6f, 14.16f, 0.51f), //Ball 10
		new Vector3(-13.5f, 14.16f, 2), //Ball 11
		new Vector3(-10.9f, 14.16f, -0.51f), //Ball 12
		new Vector3(-13.5f, 14.16f, 0), //Ball 13
		new Vector3(-12.6f, 14.16f, -1.53f), //Ball 14
		new Vector3(-11.7f, 14.16f, 1), //Ball 15
	};

	private GameObject[] balls = new GameObject[16];

	private TurnManager tm;

	private TestMove tb;

	// Use this for initialization
	void Start () {
		for (int i = 0; i < balls.Length; i++) {
			balls[i] = Instantiate(AssetDatabase.LoadAssetAtPath<GameObject>("Assets/Prefabs/Ball_" + i + ".prefab"));
			balls[i].name = i==0? "whiteBall" : "Ball_" + i;
			balls[i].transform.position = InitBallPositions[i];
			balls[i].GetComponent<BallScript>().BallNumber = i;
			balls[i].transform.SetParent(transform);
		}
		tm = GameObject.Find("TurnManager").GetComponent<TurnManager>();
		tm.wb = balls[0].GetComponent<WhiteBall>();
	}
	
	// Update is called once per frame
	void Update () {
		int stopped = 0;
		for (int i = 0; i < balls.Length; i++) {
			if (balls[i].GetComponent<BallScript>().isStopped()) {
				stopped++;
			}
		}
		if (stopped == 16) {
			tm.ChangeTurn();
		}
	}

	public void resetWhiteBall() {
		balls[0].GetComponent<Rigidbody>().velocity = new Vector3(0,0,0);
		balls[0].transform.position = InitBallPositions[0];
		balls[0].GetComponent<BallScript>().holed = false;
	}
}
