using Boo.Lang;
using UnityEngine;
using UnityEngine.UI;

public class TurnManager : MonoBehaviour {

	public int CurrentTurn;

	public int PlayerOne;

	public int PlayerTwo;

	public bool Fault;

	public bool MoveFault;
	private bool otherFault;
	private bool stopped;

	private Text turn;
	private Text playerOne;
	private Text playerTwo;
	private Text fault;
	public bool Changed;
	private TestMove tb;
	private List<string> currentTurnBallsIn;
	// Use this for initialization
	void Start () {
		PlayerOne = 0;
		PlayerTwo = 0;
		Changed = false;
		currentTurnBallsIn = new List<string>();
		turn = GameObject.Find("Turn").GetComponent<Text>();
		playerOne = GameObject.Find("PlayerOne").GetComponent<Text>();
		playerTwo = GameObject.Find("PlayerTwo").GetComponent<Text>();
		fault = GameObject.Find("Fault").GetComponent<Text>();
		tb = GameObject.Find("taco bilha").GetComponent<TestMove>();

	}


	// Update is called once per frame
	void Update () {
		turn.text = "player " + (CurrentTurn == 1? "One" : "Two");
		playerOne.text = "Player1: " + (PlayerOne == 1 ? "Plain" : "Striped");
		playerTwo.text = "Player2: " + (PlayerTwo == 1 ? "Plain" : "Striped");
		fault.text = "Fault: " + Fault;
	}

	public void ChangeTurn() {
		if (!Changed) {
			Changed = true;
			tb.show = true;
//			tb.transform.position = new Vector3(0f, 100f, 0f);
			
			if (Fault || MoveFault) { //si hizo falta en este tiro le doy al otro 2 tiros
				CurrentTurn = CurrentTurn == 1 ? 2 : 1;
				currentTurnBallsIn.Clear();
				otherFault = true;
				Fault = false;
				MoveFault = false;
			} else if (otherFault) { //pasa el primer tiro del q tiene 2 tiros
				otherFault = false;
			} else {
				if (currentTurnBallsIn.Count == 0 || tagToInt(currentTurnBallsIn[0]) != (CurrentTurn == 1 ? PlayerOne: PlayerTwo)) {
					CurrentTurn = CurrentTurn == 1 ? 2 : 1;					
				}
				currentTurnBallsIn.Clear();

			}
		}
	}

	public void inBall(string ballTag) {
		currentTurnBallsIn.Add(ballTag);
		if (CurrentTurn == 1 && PlayerOne == 0 && tagToInt(ballTag) != 3 && tagToInt(ballTag) != 0) {
			PlayerOne = tagToInt(ballTag);
			PlayerTwo = PlayerOne == 1 ? 2 : 1;
		} else if (CurrentTurn == 2 && PlayerTwo == 0 && tagToInt(ballTag) != 3 && tagToInt(ballTag) != 0) {
			PlayerTwo = tagToInt(ballTag);
			PlayerOne = PlayerTwo == 1 ? 2 : 1;
		}
	}
	
	private int tagToInt(string tagg) {
		switch (tagg) {
			case "BlackBall": return 3;
			case "StripeBall": return 2;
			case "PlainBall": return 1;
			default: return 0;
		}
	}
}
