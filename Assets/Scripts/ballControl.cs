using UnityEngine;
using System.Collections;

public class ballControl : MonoBehaviour {

    //[SerializeField]
	//Fields
    public static float rotation;
    public float rotationSpeed;
    public int jumpHeight;
	public int directionalInf; //Force multiplier to add while ball is in air
    private float distToGround;


	//Objects
    public AudioClip Hit1, Hit2, Hit3;
    public float setSFXVolume;

    void Start () {   
		GetComponent<AudioSource>().volume = setSFXVolume; //Set volume of SFX
		distToGround = GetComponent<Collider>().bounds.extents.y;  //Get Distance to ground from center of ball
    }


	void Update () {
        //Ball Movement
        rotation = Input.GetAxis("Horizontal") * rotationSpeed; // Get horizontal input from user and multiply by rotation speed
        rotation *= Time.deltaTime;
        GetComponent<Rigidbody>().AddRelativeTorque(Vector3.back * rotation);

        //Jumping
        if (Input.GetKeyDown(KeyCode.UpArrow) && isGrounded())
        {
			GetComponent<Rigidbody>().velocity += new Vector3(0, jumpHeight, 0);
        }

		//In Air Force
		if (!isGrounded()) {
			GetComponent<Rigidbody>().AddForce(new Vector3(Input.GetAxis("Horizontal") * directionalInf, 0, 0));
		}
    }

	//Shoot inivisible line down from center of ball to check if inside a boundary (in this case the ground) Return true if yes/false if no
    bool isGrounded() 
    {
        return Physics.Raycast(transform.position, -Vector3.up, distToGround + 0.1f);
    }

	//When ball enters the box collider of the ground, play a sound
	void OnCollisionEnter(Collision colInfo)
    {
			if (colInfo.collider.tag == "Platform") { // Only make sound if colliding with a platform
				int hitRand = Random.Range (0, 3);
				switch (hitRand) {
				case 0:
					GetComponent<AudioSource> ().clip = Hit1;
					break;
				case 1:
					GetComponent<AudioSource> ().clip = Hit2;
					break;
				case 2:
					GetComponent<AudioSource> ().clip = Hit3;
					break;
				default:
					Debug.Log ("Bad Random");
					break;
				}
				GetComponent<AudioSource> ().pitch = Random.Range (0.9f, 1.1f); // Pick a random pitch
				GetComponent<AudioSource> ().Play ();
			}
    }
		
}


