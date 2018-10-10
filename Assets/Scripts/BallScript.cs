using UnityEngine;
using System.Collections;

public class BallScript : MonoBehaviour {
	private Rigidbody rigid;
	private Vector3 lastVelocity;

	private WhiteBall whiteBall;

	// Initial balls positions X, Z in ball number order
	public static ArrayList InitBallPositions = new ArrayList{
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
	private float minHeight = 10;

	// Use this for initialization
	private TurnManager tm;

	public int BallNumber;

	void Start () {
		rigid = GetComponent<Rigidbody>();
		tm = GameObject.Find("TurnManager").GetComponent<TurnManager>();
		whiteBall = GetComponent<WhiteBall>();
	}

	// Update is called once per frame

	void Update () {
		if(transform.position.y <= minHeight){
			transform.position = (Vector3)InitBallPositions[BallNumber];
			rigid.velocity = new Vector3(0,0,0);
		}

		lastVelocity = rigid.velocity;
		if(rigid.velocity.magnitude <= 0.8f && rigid.velocity.magnitude > 0.0001) {
			//print(rigid.velocity.magnitude);
			rigid.velocity = new Vector3(0,0,0);
			if (CompareTag("WhiteBall")) {
				//mostrar palo
				//cambiar de turno
				whiteBall.First = 0;
				tm.ChangeTurn();
			}
		} else if (rigid.velocity.magnitude >= 20f && lastVelocity.magnitude > 0.8f) {
			rigid.velocity = lastVelocity;

		}
	}
}
