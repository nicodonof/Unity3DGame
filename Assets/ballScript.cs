using UnityEngine;

public class ballScript : MonoBehaviour {
	private Rigidbody rigid;
	private Vector3 lastVelocity;

	// Use this for initialization
	private TurnManager tm;
	
	void Start () {
		rigid = GetComponent<Rigidbody>();
		tm = GameObject.Find("TurnManager").GetComponent<TurnManager>();
	}

	// Update is called once per frame

	void Update () {
		print(rigid.velocity.magnitude);
		lastVelocity = rigid.velocity;
		if(rigid.velocity.magnitude <= 0.8f){
			rigid.velocity = new Vector3(0,0,0);
		}else if(rigid.velocity.magnitude >= 20f && lastVelocity.magnitude > 0.8f){
			rigid.velocity = lastVelocity;
		//dentro de cunado frena la bola
		//en realidad deberia ser cuando todas las bolas frenan
		if (CompareTag("WhiteBall")) {
			//mostrar palo
			//cambiar de turno
			tm.ChangeTurn();
		}
	}
}
