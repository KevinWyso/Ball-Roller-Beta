using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class currentScoreGUI : MonoBehaviour {

	//Fields

	//Objects
	public Text scoreText;
	public Text levelText;

	// Update is called once per frame
	void Update () {
		scoreText.text = "LEVEL SCORE: " + gameData.currentScore;
		levelText.text = "LEVEL: " + SceneManager.GetActiveScene ().buildIndex;
	}
}
