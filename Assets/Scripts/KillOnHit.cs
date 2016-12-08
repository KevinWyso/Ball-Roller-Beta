using UnityEngine;
using System.Collections;

public class KillOnHit : MonoBehaviour {

	gameData masterObj;

	void Start(){
		masterObj = GameObject.FindGameObjectWithTag ("Master").GetComponent<gameData>(); // Get access to masterObject 
	}

	//Kill ball player on hit and restart
	void OnTriggerEnter(Collider colInfo){ //colInfo passed is the object which passes into the kilbox
		if (!gameData.isRestarting) {
			if (colInfo.tag == "Player") { // Is the object the player?
				//Destruct the player's ball
				destructObject destructable = colInfo.GetComponent ("destructObject") as destructObject; //Get access to destructable object script on the Ball
				destructable.Destruct();

				//Restart the level
				StartCoroutine (masterObj.restartLevel ());
				masterObj.restartLevel ();
			}
		}
		
	}
}
