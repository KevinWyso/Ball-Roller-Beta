using UnityEngine;
using System.Collections;
using Math = System.Math;

public class transformPos : MonoBehaviour {

	//Fields
	public Vector3 speed;
	public float distToTravel;
	public bool waitForBall;

	bool waiting = false;
	Vector3 original;
	bool goBack = false;
	float distTravelled = 0;

	//Get original position
	void Start(){
		if (waitForBall)
			waiting = true;
		original = transform.position;
	}

	// Update is called once per frame
	void Update () {
		//Debug.Log ("Distance Travelled: " + distTravelled);
		//Debug.Log ("Distance To Travel: " + distToTravel);
		if (!waiting) { // If  not waiting for the ball
			if (goBack) { //Go backwards
				if (Math.Abs (distTravelled) < Math.Abs (distToTravel)) {
					distTravelled += speed.magnitude;
					transform.position -= speed;
				} else if (distTravelled >= distToTravel) {
					goBack = false;
					distTravelled = 0;
					if(waitForBall)
						waiting = true;
				}
			} else { //Go forwards
				if (Math.Abs (distTravelled) < Math.Abs (distToTravel)) {
					transform.position += speed;
					distTravelled += speed.magnitude;
				} else if (distTravelled >= distToTravel) {
					goBack = true;
					distTravelled = 0;
					if(waitForBall)
						waiting = true;
				}
			}
		}

		//Reset to original position upon restarting
		if (gameData.isRestarting) {
			transform.position = original;
			if (waitForBall)
				waiting = true;
			distTravelled = 0;
			goBack = false;
		}
	}

	//When ball collides with the platform, start to set it in motion
	void OnCollisionEnter(){
		if (waitForBall) {
			waiting = false;
		}
	}
}
