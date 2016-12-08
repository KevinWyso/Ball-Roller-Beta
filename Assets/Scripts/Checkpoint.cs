using UnityEngine;
using System.Collections;

public class Checkpoint : MonoBehaviour {

    //[SerializeField]
	public static Vector3 cpReached = new Vector3(0,1,0); // Default Init value is the start point of the ball in the scene
    public Vector3 debugCP;
    public ParticleSystem cpEffect; // Particle System attached to Checkpoint
	bool reached = false;

	void OnTriggerEnter(Collider obj)
    {

		if(obj.tag == "Player" && !reached)   // If Ball enters Checkpoint and is further along the X than a previous Checkpoint
        {
			reached = true;
            cpReached = obj.transform.position; //Set Reached Checkpoint Vector to ball's curr position
            cpEffect.Stop(); //Stop the particle effect
        }

    }
}
