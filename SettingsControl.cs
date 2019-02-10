/*
 * Company: Molotov Industries
 * Author: Evan Brooks
 * Date: 12-17-2018
 * Project: Color Riot
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * _____________________________________________________________________________________________________________________________________________________
 * Class to manage user preferences
 * SettingsControl
 */

public class SettingsControl : MonoBehaviour {

	/*
	 * _____________________________________________________________________________________________________________________________________________________
	 * Variables and Objects
	 */

	//Singleton - variable reference to class; static = only 1 instance
	public static SettingsControl stInstance;

	//Initialize random object to store random timer intervals
	System.Random tRandom = new System.Random();

	//Declare variables to store gameplay settings
	public int playerCount;
	public int scoreThreshold;
	public double timerInterval;


	//Initialize variables to store toggle of fancy colors preferences
	private static bool fancyCreated = false;
	private static bool fancierCreated = false;

	//Initialize variable to check creation of game object
	private static bool objectCreated = false;

	/*
	 * _____________________________________________________________________________________________________________________________________________________
	 * Settings Configuration
	 */

	//These functions check user preferences input through UI and adjust game settings

	public void PlayerSettings(int count)
	{
		playerCount = count;
		Debug.Log("Players setting: " + playerCount.ToString());
	}

	public void ScoreSettings(int threshold)
	{
		scoreThreshold = threshold;
		Debug.Log("Score setting: " + scoreThreshold.ToString());
	}

	public void TimerSettings(double interval)
	{
		timerInterval = interval;
		Debug.Log("Timer setting: " + timerInterval.ToString());
	}

	public void TimerSettingsAlt()
	{
		timerInterval = tRandom.Next(10000, 60000);
		Debug.Log("Timer ran setting: " + timerInterval.ToString());
	}

	public void FancyColorsSettings()
	{
		//Toggle state of Fancy Colors preference
		if (fancyCreated == false)
			fancyCreated = true;
		else
			fancyCreated = false;

		if (fancyCreated == true)
		{
			GameControl.gmInstance.item.FancyColorsSetup();
			Debug.Log("Adding fancy colors to color list");
		}
		else if (fancyCreated == false)
		{
			GameControl.gmInstance.item.FancyColorsRemove();
			Debug.Log("Removing fancy colors from color list");
		}
	}

	public void FancierColorsSettings()
	{
		//Toggle state of Fancy Colors preference
		if (fancierCreated == false)
			fancierCreated = true;
		else
			fancierCreated = false;

		if (fancierCreated == true)
		{
			GameControl.gmInstance.item.FancierColorsSetup();
			Debug.Log("Adding fancier colors to color list");
		}
		else if (fancierCreated == false)
		{
			GameControl.gmInstance.item.FancierColorsRemove();
			Debug.Log("Removing fancier colors from color list");
		}
	}

	public void DefaultColorsSettings(bool check1, bool check2)
	{
		if (check1 == true)
		{
			GameControl.gmInstance.item.FancyColorsRemove();
			Debug.Log("Removing fancy colors from color list");
		}

		if(check2 == true)
		{
			GameControl.gmInstance.item.FancierColorsRemove();
			Debug.Log("Removing fancier colors from color list");
		}
	}

	public void ResetAllSettings()
	{
		playerCount = 0;
		scoreThreshold = 500;
		timerInterval = 30000;

		//For togglegroups -> "SetAllTogglesOff()" function does not work
		//UIControl.uiInstance.scoreSettings.SetAllTogglesOff();
		//UIControl.uiInstance.timerSettings.SetAllTogglesOff();

		//Workaround ->
		UIControl.uiInstance.score1000.isOn = false;
		UIControl.uiInstance.score750.isOn = false;
		UIControl.uiInstance.score500.isOn = false;
		UIControl.uiInstance.score250.isOn = false;
		UIControl.uiInstance.timer45.isOn = false;
		UIControl.uiInstance.timer30.isOn = false;
		UIControl.uiInstance.timer15.isOn = false;
		UIControl.uiInstance.timerXX.isOn = false;

		UIControl.uiInstance.addFancy.isOn = false;
		UIControl.uiInstance.addFancier.isOn = false;

		//Set defaults in settings UI
		UIControl.uiInstance.score500.isOn = true;
		UIControl.uiInstance.timer30.isOn = true;
	}

	/*
	 * _____________________________________________________________________________________________________________________________________________________
	 * Game Time
	 */

	// Use this for initialization
	void Start()
	{
		//If the gameObject has not been created, initialize the singleton (variable to reference its own class)
		//and set the object to not be destroyed
		if (objectCreated == false)
		{
			stInstance = this;

			DontDestroyOnLoad(this.gameObject);
			objectCreated = true;

			Debug.Log("Awake: " + this.gameObject);
		}
	}
}
