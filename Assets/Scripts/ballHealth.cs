using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class ballHealth : MonoBehaviour {

	//[SerializeField]
	//Fields
    int lowBounds = -10; //Minimum position for ball to fall before restarting

	//Objects
	public gameData masterObj; //Master Object to access isRestarting

	void Update () {
	    if(transform.position.y <= lowBounds) //Check if ball has fallen out of bounds or not 
        {
			if (!gameData.isRestarting) {
				StartCoroutine(masterObj.restartLevel());
                masterObj.restartLevel();
            }   
        }
	}

      
}
