using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

	//[SerializeField]
	//Fields
	int bounceHeight = 9; // How high the ball will bounce after killing an enemy
	public bool isDead = false;

	//Objects
	Rigidbody player;
	public ParticleSystem death; //Death particles
	public Animator walk; //Walking animation
	private Animator center; //Movement animator 
	public Transform triggerBoxes; // Hit/kill/colliders
	public AudioSource deathSound;

	//Upon spawning do this
	void Awake(){
		center = transform.GetComponentInParent<Animator> (); //Get the Basic Enemy Object
	}

	//Kill the enemy
	public void Die(){
		//Add to players y velocity (bounce)
		player = GameObject.Find("Ball").GetComponent<Rigidbody>();
		player.velocity = new Vector3(player.velocity.x, bounceHeight, player.velocity.z);

		//Play Death Sound
		deathSound = gameObject.GetComponentInParent<AudioSource> ();
		deathSound.Play ();

		//Kill enemy
		Instantiate (death, walk.transform.position, walk.transform.rotation); // Create death particles
		walk.SetBool ("die", true); //Trigger the Enemy to play its dying animation
		center.SetBool ("stop", true); //Trigger the Basic Enemy Object to cease its movement
		triggerBoxes.gameObject.SetActive(false); // Disable hitboxes to stop player from colliding with it
		isDead = true;
		//Destroy (gameObject,3f); //(if want to destroy sprite as well) should just disable graphics instead though
	}

	//Undo the above changes to respawn enemy upon player death
	public void Respawn(){
		isDead = false;
		Debug.Log (gameObject.name + " Respawned");
		walk.SetBool("die", false); 
		center.SetBool ("stop", false);
		triggerBoxes.gameObject.SetActive(true); 
	}

}
