using Boo.Lang;
using UnityEngine;
using UnityEngine.UI;

public class TurnManager : MonoBehaviour {

	public int CurrentTurn;

	//0 white, 1 plain, 2 striped, 3 black
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
	private int stripedIn;
	private int plainIn;
	public WhiteBall wb;
	// Use this for initialization
	void Start () {
		stripedIn = 0;
		plainIn = 0;
		PlayerOne = 0;
		PlayerTwo = 0;
		Changed = false;
		currentTurnBallsIn = new List<string>();
		turn = GameObject.Find("Turn").GetComponent<Text>();
		playerOne = GameObject.Find("PlayerOne").GetComponent<Text>();
		playerTwo = GameObject.Find("PlayerTwo").GetComponent<Text>();
		fault = GameObject.Find("Fault").GetComponent<Text>();
		tb = GameObject.Find("taco bilha").GetComponent<TestMove>();
//		wb = GameObject.Find("whiteBall").GetComponent<WhiteBall>();
	}


	// Update is called once per frame
	void Update () {
		turn.text = "player " + (CurrentTurn == 1? "One" : "Two");
		playerOne.text = "Player1: " + (PlayerOne == 1 ? "Plain" : (PlayerOne == 2 ? "Striped": "Black"));
		playerTwo.text = "Player2: " + (PlayerTwo == 1 ? "Plain" : (PlayerTwo == 2 ? "Striped": "Black"));
		fault.text = "Fault: " + Fault;
	}

	public void ChangeTurn() {
		if (!Changed) {
			Changed = true;
			tb.show = true;
//			tb.transform.position = new Vector3(0f, 100f, 0f);
			if (wb.First == 0) {
				Fault = true;
			}
			wb.First = 0;

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
		if (ballTag.Equals("StripeBall")) {
			stripedIn++;
		} else if (ballTag.Equals("PlainBall")) {
			plainIn++;
		} else if (ballTag.Equals("BlackBall")) {
			if (CurrentTurn == 1 && PlayerOne == 3) {
				playerOne.text = "Gano Player 1";
			} else if (CurrentTurn == 2 && PlayerTwo == 3) {
				playerTwo.text = "Gano Player 2";
			}
			else {
				turn.text = "Gano Player " + (CurrentTurn == 1 ? 2 : 1);
				GetComponent<PauseScript>().ShowGameEndedPanel(turn.text);
			}
		} else if (ballTag.Equals("WhiteBall")) {
			Fault = true;
		}

		if (stripedIn == 7) {
			if (PlayerOne == 1) {
				PlayerOne = 3;
			} else {
				PlayerTwo = 3;
			}
		}

		if (plainIn == 7) {
			if (PlayerOne == 2) {
				PlayerOne = 3;
			} else {
				PlayerTwo = 3;
			}
		}

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
