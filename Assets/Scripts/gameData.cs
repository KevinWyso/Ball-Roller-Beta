using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class gameData : MonoBehaviour {

	//Game Data work along with the Master Object
	//Controls Music, Scoring (GUI and values), and Restarting the Level

    //[SerializeField]
    public static int currentScore;
	public static int totalScore = 0;
	//int publicScore; //D

	//Used to tell if the game is in it's restart method call, locks out from repeating the restart while already restarting
	public static bool isRestarting;

	//Objects
    public Transform musicPF;
	public Transform ball;
	public AudioClip gameOverS;
	public Enemy[] enemies;


    // Initialization of Music and Score
    void Start () {
        currentScore = 0;

        if (!GameObject.FindGameObjectWithTag("Music")) // If music object not found, create one. Used to stop from creating multiple music sources upon reloading
        {
			musicPF.GetComponent<AudioSource> ().volume = menuScript.musicVol;

			Object musicManager = Instantiate (musicPF, transform.position, Quaternion.identity); //Quaternion.identity = No rotation
            musicManager.name = musicPF.name;
			DontDestroyOnLoad(musicManager); //Object persist through reloads (Doesn't restart music which might annoy the player)
        }
	}

	void Update () {
		//Update Score every frame
        //publicScore = currentScore; //D
	}


	public IEnumerator restartLevel()
	{
		//Disable control of ball when dead
		ball.GetComponent<ballControl> ().enabled = false; 
		isRestarting = true;

		//Set Game Over Sound to play
		GetComponent<AudioSource>().pitch = 1;
		GetComponent<AudioSource>().clip = gameOverS;
		GetComponent<AudioSource>().Play();

		//Wait til Sound finishes
		yield return new WaitForSeconds(GetComponent<AudioSource>().clip.length);

		//Reset to prev checkpoint
		ball.transform.position = Checkpoint.cpReached;
		ball.GetComponent<Rigidbody>().angularVelocity *= 0;
		ball.GetComponent<Rigidbody> ().velocity = Vector3.zero;

		//Re-enable ball control
		ball.GetComponent<ballControl> ().enabled = true; 

		//Get the Destructable Object Script from the ball and use it's methods to reset the ball to it's unbroken state
		destructObject destructable = ball.GetComponent ("destructObject") as destructObject; //Get destructable object
		destructable.ResetBall();

		//Penalize 1 coin from currentScore per death
		if (currentScore > 0)
			currentScore--;

		//Respawn Enemies
		for (int i = 0; i < enemies.Length; i++) {
			if(enemies[i].isDead == true)
				enemies [i].Respawn ();
		}

		//Unlock
		isRestarting = false;
	}

	//Loads next level in the build settings, can add parameters if necessary
	public void loadNextLevel(){
		totalScore += currentScore;
		Debug.Log (SceneManager.GetActiveScene ().buildIndex + 1);
		SceneManager.LoadScene (SceneManager.GetActiveScene().buildIndex + 1);
		Checkpoint.cpReached = new Vector3(0,1,0);
	}

}
