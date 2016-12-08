using UnityEngine;
using System.Collections;

public class resetOrientation : MonoBehaviour {

	//Objects
	//Quaternion original;
	//Fields

	//Get original orientation
	void Start(){
		//original = transform.rotation;
	}
		
	//Check if restarting, if restarting, reset the orientation of the object
	void Update(){
		if (gameData.isRestarting) {
			//Debug.Log ("Restarting");
			transform.rotation = Quaternion.identity;
		}
	}

}
