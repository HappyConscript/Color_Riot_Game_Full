/*
 * Company: Molotov Industries
 * Author: Evan Brooks
 * Date: 12-15-2018
 * Project: Color Riot
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*
 * _____________________________________________________________________________________________________________________________________________________
 * Class to manage user interface functionality
 * UIControl
 */

public class UIControl : MonoBehaviour {

	/*
	 * _____________________________________________________________________________________________________________________________________________________
	 * Variables and Objects
	 */

	//Singleton - variable reference to class; static = only 1 instance
	public static UIControl uiInstance;

	//Declare variables to store references to game info on UI
	public Text objekt;
	public Text color;

	//Declare variables to store references to player stats on UI
	public Text playerNum;
	public Text playerCurrentScore;
	public Text playerFinalScore;

	public List<Text> playerScoreLbls = new List<Text>();
	public List<Text> playerScoreTracks = new List<Text>();

	public Text goal;

	//For togglegroups -> "SetAllTogglesOff()" function does not work
	//public ToggleGroup scoreSettings;
	//public ToggleGroup timerSettings;

	//Workaround ->
	public Toggle score1000;
	public Toggle score750;
	public Toggle score500;
	public Toggle score250;
	public Toggle timer45;
	public Toggle timer30;
	public Toggle timer15;
	public Toggle timerXX;

	public Toggle addFancy;
	public Toggle addFancier;

	//Declare variables to store references to UI panels
	public GameObject mainPanel;
	public GameObject creditsPanel;
	public GameObject credits2Panel;
	public GameObject help1Panel;
	public GameObject help2Panel;
	public GameObject help3Panel;
	public GameObject playersPanel;
	public GameObject settingsPanel;
	public GameObject readyPanel;
	public GameObject playPanel;
	public GameObject overPanel;

	//Declare variables to store sound controls
	public Button musicToggle;
	public Button soundToggle;
	public Image musicOff;
	public Image soundOff;

	public Image musicDisImgOn;
	public Image musicDisImgOff;
	private Color musicDisCol;

	//Initialize variable to check creation of game object
	private static bool objectCreated = false;

	/*
	 * _____________________________________________________________________________________________________________________________________________________
	 * UI Control
	 */

	//These functions manipulate the user interface and call other functions from GameControl and SoundControl

	public void PlayBtn() //Main Menu + Players Menu
	{
		SoundControl.scInstance.btnClickSfxPlay();

		mainPanel.SetActive(false);
		playersPanel.SetActive(true);
	}

	public void CreditsBtn(int index) //Main Menu + Credits Menus
	{
		SoundControl.scInstance.btnClickSfxPlay();

		if (index == 1)
		{
			mainPanel.SetActive(false);
			creditsPanel.SetActive(true);
		}
		else if (index == 2)
		{
			creditsPanel.SetActive(false);
			credits2Panel.SetActive(true);
		}
		else if (index == 3)
		{
			credits2Panel.SetActive(false);
			mainPanel.SetActive(true);
		}
	}

	public void HelpBtn(int index) //Help Menus + Main Menu
	{
		SoundControl.scInstance.btnClickSfxPlay();

		if (index == 1)
		{
			mainPanel.SetActive(false);
			help1Panel.SetActive(true);
		}
		else if (index == 2)
		{
			help1Panel.SetActive(false);
			help2Panel.SetActive(true);
		}
		else if (index == 3)
		{
			help2Panel.SetActive(false);
			help3Panel.SetActive(true);
		}
		else if (index == 0)
		{
			help3Panel.SetActive(false);
			mainPanel.SetActive(true);
		}
	}

	public void BackBtn(int index) //Help Menus + Players Menu
	{
		SoundControl.scInstance.btnClickSfxPlay();

		if (index == 1)
		{
			help1Panel.SetActive(false);
			mainPanel.SetActive(true);
		}
		else if (index == 2)
		{
			help2Panel.SetActive(false);
			help1Panel.SetActive(true);
		}
		else if (index == 3)
		{
			help3Panel.SetActive(false);
			help2Panel.SetActive(true);
		}
		else if (index == 4)
		{
			playersPanel.SetActive(false);
			mainPanel.SetActive(true);
		}
		else if (index == 5)
		{
			credits2Panel.SetActive(false);
			creditsPanel.SetActive(true);
		}
		else if (index == 0)
		{
			creditsPanel.SetActive(false);
			mainPanel.SetActive(true);
		}
	}

	public void musicToggleBtn() //Music mute toggle button
	{
		MusicControl.mcInstance.muteToggle();

		if (musicOff.enabled == false)
			musicOff.enabled = true;
		else
			musicOff.enabled = false;
	}

	public void soundToggleBtn() //Sound mute toggle button
	{
		SoundControl.scInstance.muteToggle();

		if (soundOff.enabled == false)
			soundOff.enabled = true;
		else
			soundOff.enabled = false;
	}

	public void PlayersBtn(int index) //Players Menu + Settings Menu
	{
		SoundControl.scInstance.btnClickSfxPlay();

		if (index == 2)
		{
			SettingsControl.stInstance.PlayerSettings(2);
		}
		else if (index == 3)
		{
			SettingsControl.stInstance.PlayerSettings(3);
		}
		else if (index == 4)
		{
			SettingsControl.stInstance.PlayerSettings(4);
		}

		playersPanel.SetActive(false);
		settingsPanel.SetActive(true);
	}

	public void ScoreSettings(int index) //Adjust score threshold using checkboxes
	{
		SoundControl.scInstance.btnClickSfxPlay();

		if (index == 1)
		{
			SettingsControl.stInstance.ScoreSettings(1000);
		}
		else if (index == 2)
		{
			SettingsControl.stInstance.ScoreSettings(750);
		}
		else if (index == 3)
		{
			SettingsControl.stInstance.ScoreSettings(500);
		}
		else if (index == 0)
		{
			SettingsControl.stInstance.ScoreSettings(250);
		}
	}

	public void TimerSettings (int index) //Adjust timer interval using checkboxes
	{
		SoundControl.scInstance.btnClickSfxPlay();

		if (index == 1)
		{
			SettingsControl.stInstance.TimerSettings((double)45000);
		}
		else if (index == 2)
		{
			SettingsControl.stInstance.TimerSettings((double)30000);
		}
		else if (index == 3)
		{
			SettingsControl.stInstance.TimerSettings((double)15000);
		}
		else if (index == 0)
		{
			SettingsControl.stInstance.TimerSettingsAlt();
		}
	}

	public void DifficultySettings(int index) //Adjust difficulty using checkboxes
	{
		SoundControl.scInstance.btnClickSfxPlay();

		if (index == 0)
		{
			SettingsControl.stInstance.FancyColorsSettings();
		}
		else if (index == 1)
		{
			SettingsControl.stInstance.FancierColorsSettings();
		}
	}

	public void StartBtn() //Settings Menu + Ready Screen
	{
		SoundControl.scInstance.btnClickSfxPlay();

		if (MusicControl.mcInstance.isMuted == false)
		{
			MusicControl.mcInstance.muteComplete();
		}

		settingsPanel.SetActive(false);
		readyPanel.SetActive(true);

		UIControl.uiInstance.musicToggle.enabled = false;
		MusicBtnDisable();
	}

	public void ReadyBtn() //Ready Screen + Play Screen
	{
		SoundControl.scInstance.btnClickSfxPlay();
		GameControl.gmInstance.GameSetup();

		readyPanel.SetActive(false);
		playPanel.SetActive(true);
	}

	public void CorrectBtn() //Play Screen
	{
		SoundControl.scInstance.btnClickSfxPlay();
		EffectsControl.ecInstance.btnClick50VfxPlay();
		GameControl.gmInstance.RefreshGameAdd();
	}

	public void RedrawBtn() //Play Screen
	{
		SoundControl.scInstance.btnClickSfxPlay();
		EffectsControl.ecInstance.btnClick25VfxPlay();
		GameControl.gmInstance.RefreshGameSub();
	}

	public void RematchBtn() //Over Screen + Ready Screen
	{
		SoundControl.scInstance.btnClickSfxPlay();

		if (MusicControl.mcInstance.isMuted == false)
		{
			MusicControl.mcInstance.muteComplete();
		}

		GameControl.gmInstance.RematchGame();

		overPanel.SetActive(false);
		readyPanel.SetActive(true);

		MusicBtnDisable();
	}

	public void FinishBtn() //Over Screen + Main Menu
	{
		SoundControl.scInstance.btnClickSfxPlay();
		GameControl.gmInstance.ResetGame();

		overPanel.SetActive(false);
		mainPanel.SetActive(true);
	}

	public void HomeBtn() //Return To Main Menu
	{
		SoundControl.scInstance.btnClickSfxPlay();
		SoundControl.scInstance.timerStartSfxStop();

		if (MusicControl.mcInstance.isMuted == false)
		{
			MusicControl.mcInstance.unmuteComplete();
		}
		
		GameControl.gmInstance.ResetGame();

		//Set all panels to inactive
		creditsPanel.SetActive(false);
		credits2Panel.SetActive(false);
		help1Panel.SetActive(false);
		help2Panel.SetActive(false);
		help3Panel.SetActive(false);
		playersPanel.SetActive(false);
		settingsPanel.SetActive(false);
		readyPanel.SetActive(false);
		playPanel.SetActive(false);
		overPanel.SetActive(false);

		mainPanel.SetActive(true);

		MusicBtnEnable();
	}

	public void ExitBtn() //Exit Game
	{
		Application.Quit();
	}

	public void MusicBtnDisable() //Change transparency of music toggle btn
	{
		UIControl.uiInstance.musicToggle.enabled = false;

		musicDisCol.a = (float)0.50;
		musicDisCol.r = 255;
		musicDisCol.g = 255;
		musicDisCol.b = 255;

		musicDisImgOn.color = musicDisCol;
		musicDisImgOff.color = musicDisCol;
	}

	public void MusicBtnEnable() //Change transparency of music toggle btn
	{
		UIControl.uiInstance.musicToggle.enabled = true;

		musicDisCol.a = (float)1.00;
		musicDisCol.r = 255;
		musicDisCol.g = 255;
		musicDisCol.b = 255;

		musicDisImgOn.color = musicDisCol;
		musicDisImgOff.color = musicDisCol;
	}

	/*
	 * _____________________________________________________________________________________________________________________________________________________
	 * Game Time
	 */

	// Use this for initialization
	void Start () {

		//If the gameObject has not been created, initialize the singleton (variable to reference its own class)
		//and set the object to not be destroyed
		if (objectCreated == false)
		{
			uiInstance = this;

			DontDestroyOnLoad(this.gameObject);
			objectCreated = true;

			Debug.Log("Awake: " + this.gameObject);
		}
	}

	// Update is called once per frame
	void Update ()
	{

	}
}
