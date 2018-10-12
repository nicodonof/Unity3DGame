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
    if((name == "HoleTM" || name == "HoleBM")
      && (other.tag == "WhiteBall" || other.tag == "BlackBall" || other.tag == "PlainBall" || other.tag == "StripeBall")){
      var auxRigid = other.gameObject.GetComponent<Rigidbody>();
      if(name == "HoleTM"){
        auxRigid.velocity = new Vector3(5, auxRigid.velocity.y, auxRigid.velocity.z);
      }else{
        auxRigid.velocity = new Vector3(-5, auxRigid.velocity.y, auxRigid.velocity.z);
      }
    }
		//print(other.name);
	}
}
