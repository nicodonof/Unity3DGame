using UnityEngine;

public class WhiteBall : MonoBehaviour {

	public int First;

	private TurnManager tm;
	
	void Start () {
		tm = GameObject.Find("TurnManager").GetComponent<TurnManager>();
	}
	

	private void OnCollisionEnter(Collision other) {
		if (First == 0) {
			First = tagToInt(other.gameObject.tag);
			if (First != 0) {
				if ((tm.CurrentTurn == 1 && First != tm.PlayerOne) || (tm.CurrentTurn == 2 && First != tm.PlayerTwo)) {
					tm.Fault = true;
				}
			}
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
