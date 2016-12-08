using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class finalScoreGUI : MonoBehaviour {

	//Fields

	//Objects
	public Text scoreText; //Need UI import

	//Access Final score
	void Start(){
		scoreText.text = "SCORE: " + gameData.totalScore;
	}

}
