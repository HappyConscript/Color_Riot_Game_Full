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
 * Class to manage visual effects functionality
 * EffectsControl
 */

public class EffectsControl : MonoBehaviour
{

	//Singleton - variable reference to class; static = only 1 instance
	public static EffectsControl ecInstance;

	//Declare variables to store reference to audio sources
	public ParticleSystem psScore50;
	public ParticleSystem psScore25;
	public ParticleSystem psHighlight;

	/*
	 * _____________________________________________________________________________________________________________________________________________________
	 * Sound Control
	 */

	public void btnClick50VfxPlay() //Start button VFX
	{
		psScore50.Play();
		psScore50.Clear();
	}

	public void btnClick25VfxPlay() //Start button VFX
	{
		psScore25.Play();
		psScore50.Clear();
	}

	public void drawItemVfxPlay() //Start hightlight VFX
	{
		psHighlight.Play();
		psHighlight.Clear();
	}

	/*
	 * _____________________________________________________________________________________________________________________________________________________
	 * Game Time
	 */

	//Runs when the gameobject is awoken
	void Awake()
	{
		Debug.Log("EffectsControl Awake " + GetInstanceID());

		//Check if an EffectsControl object instance already exists
		//if it does, destroy the newly instantiated object
		if (ecInstance != null)
		{
			Destroy(gameObject);
			Debug.Log("Destroy duplicate EffectsControl instance");
		}
		//If an EffectsControl object instance does NOT exist, set the variable = object
		else
		{
			ecInstance = this;
			GameObject.DontDestroyOnLoad(gameObject);
		}
	}
}
