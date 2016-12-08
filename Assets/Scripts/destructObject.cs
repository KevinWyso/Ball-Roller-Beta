using UnityEngine;
using System.Collections;

public class destructObject : MonoBehaviour {

	public Rigidbody ballRB;
	public SphereCollider ballCol;
	public Transform piecesParent;
	public Transform piecesPrefab;
	public GameObject wholeBall; 

	//Destroy the object
	public void Destruct(){
		ballRB.isKinematic = true; //Set the Complete rigid body to kinematic (whether or not physics affects the body)
		ballCol.enabled = false; //Disables collision of the Complete ball
		Transform clone = Instantiate (piecesPrefab, piecesParent.position, piecesParent.rotation) as Transform; //Spawn the set of ball pieces
		//clone.SetParent (piecesParent); //
		Destroy(clone.gameObject, 2.9f); //Destroy pieces after Arg2 seconds
		wholeBall.SetActive (false); //Disable existence of the whole ball
	}

	public void ResetBall(){
		ballRB.isKinematic = false; //Opposite of Destruct method
		ballCol.enabled = true;
		wholeBall.SetActive (true);
	}
}
