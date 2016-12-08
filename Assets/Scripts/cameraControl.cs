using UnityEngine;
using System.Collections;

public class cameraControl : MonoBehaviour {

   // [SerializeField]
    public Transform ball;
    float distanceToTarget = -10, Lift = 1.5f;
	
	// Late Update called after all other updates
	void LateUpdate () {
        transform.position = ball.position + new Vector3(0, Lift, distanceToTarget); //Force camera to follow ball along the x axis, Lift units above the ball, and distanceToTarget away from it
        transform.LookAt(ball); //Keep camera facing ball
	}
}
