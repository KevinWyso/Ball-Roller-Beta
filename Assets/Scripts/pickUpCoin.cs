using UnityEngine;
using System.Collections;

public class pickUpCoin : MonoBehaviour {

    //[SerializeField]
    public Transform coinEffect; 

	// Called when entering the Trigger Box
	void OnTriggerEnter (Collider info) {
	    if(info.tag == "Player")
        {
			if (gameObject.tag == "coinYellow")
				gameData.currentScore += 1; // Increment score
			else
				gameData.currentScore += 3;
			Transform effect = (Transform) Instantiate(coinEffect, transform.position, transform.rotation); // Spawn the coin pick up effect at the coin's position (loops for short duration)
            Destroy(effect.gameObject, 3);  //Destroy Coin Effect after it plays (Frees clutter)
            Destroy(gameObject); //Destroy object the script is attached to
            
        }
	}
}
