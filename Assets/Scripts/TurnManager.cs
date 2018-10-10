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

	public Text turn;

	public bool Changed;

	// Use this for initialization
	void Start () {
		PlayerOne = 0;
		PlayerTwo = 0;
		Changed = false;
	}


	// Update is called once per frame
	void Update () {
		//turn.text = CurrentTurn.ToString();
	}

	public void ChangeTurn() {
		if (!Changed) {
			Changed = true;
			if (Fault || MoveFault) { //si hizo falta en este tiro le doy al otro 2 tiros
				CurrentTurn = CurrentTurn == 1 ? 2 : 1;
				otherFault = true;
			} else if (otherFault) { //pasa el primer tiro del q tiene 2 tiros
				otherFault = false;
			} else {
				CurrentTurn = CurrentTurn == 1 ? 2 : 1;
			}
		}
	}
}
