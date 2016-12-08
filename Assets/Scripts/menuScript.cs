using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class menuScript : MonoBehaviour {

	//public Button button;
	GameObject toDisable; //Gameobject to disable upon selecting a Button
	GameObject toEnable; //Gameobject to enable upon selecting a Button

	//Fields
	public static float musicVol = 0.7f;
	public bool inGame;
	//public static bool changed = false;

	//Objects
    public AudioSource music; //Music source

	void Start(){
		if (!inGame) { //If coming from the menu, do the default
			music.volume = musicVol; //Set global volume var
			toDisable = GameObject.FindGameObjectWithTag ("MainButtons"); // Set up which buttons will be disabled/enabled on the start menu
			toEnable = GameObject.FindGameObjectWithTag ("LevelButtons");
			toEnable.SetActive (false); //Need to do it this way so the game starts with them "technically" enabled (error otherwise)
		} else {
			music = GameObject.Find ("masterObj").GetComponent<AudioSource>(); //Set music when coming back from a restart via the menu
		}
	}

	// Quit Button
	public void quitGame () {
        Application.Quit();
	}
	
	// Start Button
	public void startLevel (string level) {
		if (inGame) { // Destroy the Music Manager upon coming to the menu from a level in order to prevent multiple music sources
			Destroy (GameObject.Find("Music Manager"));
		}
        SceneManager.LoadScene(level);
	}

	//Level Select Button (Disable Start, Quit, and Music Sliders), Enable Level Buttons, Can also be used to go back to 
	public void changeMenu(){
		toDisable.SetActive (false);
		toEnable.SetActive (true);
		swapButtons ();
	}

	//Swap the buttons to be enabled/disabled when going to the other menu
	void swapButtons(){
		GameObject temp = toEnable;
		toEnable = toDisable;
		toDisable = temp;	
	}
		
	//Set Volume in Menu
	public void setVolume(float volume)
	{
		//changed = true; // Set changed flag to note the user changed the volume in the menu
		music.volume = volume;
		musicVol = volume; // Set global music volume value for use in other scenes
	}
}
