/*
 * Company: Molotov Industries
 * Author: Evan Brooks
 * Date: 12-15-2018
 * Project: Color Riot
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * _____________________________________________________________________________________________________________________________________________________
 * Class to manage music functionality
 * MusicControl
 */

public class MusicControl : MonoBehaviour {

	/*
	 * _____________________________________________________________________________________________________________________________________________________
	 * Variables and Objects
	 */

	//Singleton - variable reference to class; static = only 1 instance
	public static MusicControl mcInstance;

	//Declare variable to store reference to audio source
	public AudioSource source;

	public bool isMuted;

	/*
	 * _____________________________________________________________________________________________________________________________________________________
	 * Music Control
	 */

	public void fadedown() //Fade music volume down
	{
		source.volume = 0.1f;
	}

	public void fadeup() //Fade music volume up
	{
		source.volume = .25f;
	}

	public void muteToggle() //Mute music according to current status
	{
		if (source.mute == false)
		{
			source.mute = true;
			isMuted = true;
		}
		else
		{
			source.mute = false;
			isMuted = false;
		}
	}

	public void muteComplete() //Mute music unconditionally
	{
		source.mute = true;
	}

	public void unmuteComplete() //Unmute music unconditionally
	{
		source.mute = false;
	}

	/*
	 * _____________________________________________________________________________________________________________________________________________________
	 * Game Time
	 */

	//Function runs when the gameobject is awoken
	void Awake()
	{
		Debug.Log("MusicPlayer Awake " + GetInstanceID());

		//Check if a MusicControl object instance already exists
		//if it does, destroy the newly instantiated object
		if (mcInstance != null)
		{
			Destroy(gameObject);
			Debug.Log("Destroy duplicate MusicPlayer instance");
		}
		//If a MusicControl object instance does NOT exist, set the variable = object
		else
		{
			mcInstance = this;
			GameObject.DontDestroyOnLoad(gameObject);
		}
	}
}
