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
 * Class to manage Sound functionality
 * SoundControl
 */

public class SoundControl : MonoBehaviour {

	//Singleton - variable reference to class; static = only 1 instance
	public static SoundControl scInstance;

	//Declare variables to store reference to audio sources
	public AudioSource btnClickSfx;
	public AudioSource timerStartSfx;
	public AudioSource timerEndSfx;

	/*
	 * _____________________________________________________________________________________________________________________________________________________
	 * Sound Control
	 */
	
	public void btnClickSfxPlay() //Play button SFX
	{
		btnClickSfx.Play();
	}

	public void timerStartSfxPlay() //Play timer sfx
	{
		Debug.Log("Starting timer SFX");
		timerStartSfx.Play();
	}

	public void timerStartSfxStop() //Stop timer sfx
	{
		Debug.Log("Ending timer SFX");
		timerStartSfx.Stop();
	}

	public void timerEndSfxPlay() //Play timer end sfx
	{
		timerEndSfx.Play();
	}

	public void muteToggle() //Mute sfx according to current status
	{
		if (btnClickSfx.mute == false /*&& timerStartSfx.mute == false && timerEndSfx.mute == false*/)
		{
			btnClickSfx.mute = true;
			timerStartSfx.mute = true;
			timerEndSfx.mute = true;
		}
		else
		{
			btnClickSfx.mute = false;
			timerStartSfx.mute = false;
			timerEndSfx.mute = false;
		}
	}

	public void muteComplete() //Mute sfx unconditionally
	{
		btnClickSfx.mute = true;
		timerStartSfx.mute = true;
		timerEndSfx.mute = true;
	}

	public void unmuteComplete() //Unmute sfx unconditionally
	{
		btnClickSfx.mute = false;
		timerStartSfx.mute = false;
		timerEndSfx.mute = false;
	}

	/*
	 * _____________________________________________________________________________________________________________________________________________________
	 * Game Time
	 */

	//Runs when the gameobject is awoken
	void Awake()
	{
		Debug.Log("SoundControl Awake " + GetInstanceID());

		//Check if a SoundControl object instance already exists
		//if it does, destroy the newly instantiated object
		if (scInstance != null)
		{
			Destroy(gameObject);
			Debug.Log("Destroy duplicate SoundControl instance");
		}
		//If a SoundControl object instance does NOT exist, set the variable = object
		else
		{
			scInstance = this;
			GameObject.DontDestroyOnLoad(gameObject);
		}
	}
}
