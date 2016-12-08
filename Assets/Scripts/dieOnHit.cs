using UnityEngine;
using System.Collections;

public class dieOnHit : MonoBehaviour {

	//When the ball enters the enemies "hitbox", start the death animation
	void OnTriggerEnter(){
		if (!gameData.isRestarting) {
			Enemy enemy = transform.GetComponentInParent<Enemy> (); //Get the Enemy script from the parent holding this hitbox
			enemy.Die (); 
		}
	}

}
