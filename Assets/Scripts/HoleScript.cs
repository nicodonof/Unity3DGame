using UnityEngine;
using System.Collections;

public class HoleScript : MonoBehaviour {

	void Start () {
	}

	// Update is called once per frame

	void Update () {
  }

	void OnTriggerEnter(Collider other){
    switch (other.tag){
      case "WhiteBall":break;
      case "BlackBall":break;
      case "PlainBall":
      case "StripeBall":break;
    }
		//print(other.name);
	}
}
