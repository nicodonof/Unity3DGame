using UnityEngine;

public class TurnManager : MonoBehaviour {

	public int CurrentTurn;

	public int PlayerOne;
	
	public int PlayerTwo;
	
	public bool Fault;

	public bool MoveFault;
	private bool otherFault;
	private bool stopped;
	
	// Use this for initialization
	void Start () {
		PlayerOne = 0;
		PlayerTwo = 0;
	}
	
	
	// Update is called once per frame
	void Update () {
	}

	public void ChangeTurn() {
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
