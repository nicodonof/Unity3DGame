using UnityEngine;
using System.Collections;

public class BallScript : MonoBehaviour {
	private Rigidbody rigid;
	private Vector3 lastVelocity;

	private WhiteBall whiteBall;

	// Initial balls positions X, Z in ball number order
	private static ArrayList initBallPositions = new ArrayList{
		new Vector2(0,20), //WhiteBall
		new Vector2(1.7f,-19.55f), //Ball 1
		new Vector2(-1.7f,-22.45f), //Ball 2
		new Vector2(0.85f,-21f), //Ball 3
		new Vector2(1.7f,-22.45f), //Ball 4
		new Vector2(3.4f,-22.45f), //Ball 5
		new Vector2(-2.55f,-21f), //Ball 6
		new Vector2(-0.85f,-18.1f), //Ball 7
		new Vector2(1,-19.55f), //Ball 8
		new Vector2(1,-16.65f), //Ball 9
		new Vector2(-0.85f,-21f), //Ball 10
		new Vector2(-3.4f,-22.45f), //Ball 11
		new Vector2(0.85f,-18.1f), //Ball 12
		new Vector2(1,-22.45f), //Ball 13
		new Vector2(2.55f,-21f), //Ball 14
		new Vector2(-1.7f,-19.55f), //Ball 15
		};

	// Use this for initialization
	private TurnManager tm;

	void Start () {
		rigid = GetComponent<Rigidbody>();
		tm = GameObject.Find("TurnManager").GetComponent<TurnManager>();
		whiteBall = GetComponent<WhiteBall>();
	}

	// Update is called once per frame

	void Update () {
		lastVelocity = rigid.velocity;
		if(rigid.velocity.magnitude <= 0.8f && rigid.velocity.magnitude > 0.0001) {
			print(rigid.velocity.magnitude);
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
