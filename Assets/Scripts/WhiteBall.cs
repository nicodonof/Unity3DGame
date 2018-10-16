using UnityEngine;

public class WhiteBall : MonoBehaviour {

	public int First;

	private TurnManager tm;
	private BallManager bm;
	void Start () {
		tm = GameObject.Find("TurnManager").GetComponent<TurnManager>();
		bm = GetComponentInParent<BallManager>();
	}
	

	private void OnCollisionEnter(Collision other) {
		if (First == 0) {
			First = tagToInt(other.gameObject.tag);
			if (First != 0) {
				if ((tm.CurrentTurn == 1 && First != tm.PlayerOne && tm.PlayerOne != 0) || (tm.CurrentTurn == 2 && First != tm.PlayerTwo && tm.PlayerTwo != 0)) {
					tm.Fault = true;
				}
			}
		}
	}

	private void OnTriggerEnter(Collider other) {
		if (other.CompareTag("Hole")) {
			bm.resetWhiteBall();
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
