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
using System.Timers; //Use namespace for timer class

/*
 * _____________________________________________________________________________________________________________________________________________________
 * Class to manage gameplay functionality
 * GameControl
 */

public class GameControl : MonoBehaviour {

	/*
	 * _____________________________________________________________________________________________________________________________________________________
	 * Variables and Objects
	 */

	//Singleton - variable reference to class; static = only 1 instance
	public static GameControl gmInstance;

	//Initialize variable to store player objects
	public List<Player> playerList = new List<Player>();

	//Initialize variable to store item object
	public Item item = new Item("","");

	//Declare variable to store timer objects
	private Timer turnTimer;

	//Initialize variable to check creation of game object
	private static bool objectCreated = false;

	//Initialize variable to check finish of timer
	private bool timerFinished = false;

	//Initialize variable to flag timer as existing
	private bool timerExists = false;

	/*
	 * _____________________________________________________________________________________________________________________________________________________
	 * Player Setup
	 */


	public void PlayerSetup() //Instantiates a number of player objects according to the selected playercount
	{
		Debug.Log("Starting player setup process");

		if(playerList.Count == 0)
		{
			int x = 0;
			int playerCountTemp = SettingsControl.stInstance.playerCount;

			while (x <= playerCountTemp - 1)
			{
				//Instantiate player object and add to playerlist
				Player player = new Player("Name", 0, false, false);
				playerList.Add(player);

				playerCountTemp--;
			}

			//Switch bool for current player status
			playerList[0].current = true;

			Debug.Log("Player count = " + SettingsControl.stInstance.playerCount);

			foreach (Player player in playerList)
			{
				Debug.Log(playerList.IndexOf(player).ToString() + "   " + player.ToString());
			}
		}
		else
		{
			Debug.Log(playerList.Count.ToString() + " Players");
		}

		ScoreTrackerSetup();
		UIControl.uiInstance.goal.text = SettingsControl.stInstance.scoreThreshold.ToString();
	}

	/*
	 * _____________________________________________________________________________________________________________________________________________________
	 * Score Tracker
	 */

	private void ScoreTrackerSetup() //Disable score tracker UI elements according to player count
	{
		int index = 4; //Max number of players
		while (index > playerList.Count)
		{
			UIControl.uiInstance.playerScoreLbls[index - 1].enabled = false; //Adjust index value for appropriate list entry
			UIControl.uiInstance.playerScoreTracks[index - 1].enabled = false;
			index--;
		}
	}

	private void ScoreTrackerUpdate() //Update score tracker UI elements according to player count
	{
		int index = 0;
		while (index <= playerList.Count - 1)
		{
			UIControl.uiInstance.playerScoreTracks[index].text = playerList[index].score.ToString();
			index++;
		}
	}

	/*
	 * _____________________________________________________________________________________________________________________________________________________
	 * Game Setup
	 */

	public void GameSetup() //Performs setup of a player's turn by drawing an item, updating the score, and starting the turn timer
	{
		DrawItem();
		UpdateScore();
		TimerSetup();
	}
	
	private void DrawItem() //Generates and displays a new object and color through Item object functions
	{
		item.RandSetup();

		EffectsControl.ecInstance.drawItemVfxPlay();

		if (UIControl.uiInstance.objekt != null)
		{
			UIControl.uiInstance.objekt.text = item.objekt;
		}

		if (UIControl.uiInstance.color != null)
		{
			UIControl.uiInstance.color.text = item.color;
		}

		Debug.Log("Item: " + item.ToString());
	}

	public void TimerSetup() //Instantiates a new timer object and beings initializes the timer with a player-selected interval
	{
		//Instantiate new timer object into reference variable to 'reset' the timer
		turnTimer = new Timer();

		timerExists = true;

		turnTimer.Interval = SettingsControl.stInstance.timerInterval; //time in milliseconds
		turnTimer.Elapsed += new ElapsedEventHandler(turnTimer_Tick);

		turnTimer.Enabled = true;

		SoundControl.scInstance.timerStartSfxPlay();

		Debug.Log("Turn timer started with " + SettingsControl.stInstance.timerInterval + "ms");
	}

	private void turnTimer_Tick(object sender, ElapsedEventArgs e) //Event handler executes when timer reaches interval time
	{
		timerFinished = true;
		turnTimer.Stop();

		Debug.Log("Turn timer ended");
	}

	/*
	 * _____________________________________________________________________________________________________________________________________________________
	 * Game Play
	 */

	public void RefreshGameAdd() //Increments the current player's score and refreshes the round
	{
		bool check;

		foreach (Player player in playerList)
		{
			if (player.current == true)
			{
				Debug.Log("Player " + playerList.IndexOf(player).ToString() + " Score: " + player.score.ToString());

				player.ScoreAdd();
				UpdateScore();

				check = player.ScoreCheck();

				if (check == true)
				{
					EndGame();
				}
				else
				{
					DrawItem();
				}
			}
		}
	}

	public void RefreshGameSub() //Decrements the current player's score and refreshes the round
	{
		foreach (Player player in playerList)
		{
			if (player.current == true)
			{
				Debug.Log("Player " + playerList.IndexOf(player).ToString() + " Score: " + player.score.ToString());

				player.ScoreSub();
				UpdateScore();

				DrawItem();
			}
		}
	}

	private void NextPlayer() //Rotates 'current' player to the 'next' player according to player count
	{
		foreach (Player player in playerList)
		{
			int index = playerList.IndexOf(player);

			if (player.current == true)
			{
				player.current = false;

				//Divide index of next player by player count and reset index as the remainder
				// % = Division W/ remainder as result // Example: 1 + 1 % 3 -> 3 goes into 2 zero times with a remainder of 2
				index = (playerList.IndexOf(player) + 1) % playerList.Count;
				playerList[index].current = true;

				//Reset timer finish check
				timerFinished = false;

				break;
			}
		}

		//Stop turn timer sound and play timer end sound
		SoundControl.scInstance.timerEndSfxPlay();
		SoundControl.scInstance.timerStartSfxStop();

		ScoreTrackerUpdate();

		//Change between UI panels
		UIControl.uiInstance.playPanel.SetActive(false);
		UIControl.uiInstance.readyPanel.SetActive(true);
	}

	private void UpdateScore() //Checks the current player's score and updates it on the UI
	{
		//Check for current player and collect info
		foreach (Player player in playerList)
		{
			if (player.current == true)
				if(UIControl.uiInstance.playerCurrentScore != null)
				{
					UIControl.uiInstance.playerCurrentScore.text = player.score.ToString();
					break;
				}
		}
	}

	private void EndGame() //Collects number and score of winning player for display
	{
		//Stop the turn timer
		turnTimer.Stop();

		//Stop turn timer sound and play timer end sound
		SoundControl.scInstance.timerEndSfxPlay();
		SoundControl.scInstance.timerStartSfxStop();

		//Change between UI panels
		UIControl.uiInstance.playPanel.SetActive(false);
		UIControl.uiInstance.overPanel.SetActive(true);

		if (MusicControl.mcInstance.isMuted == true)
		{
			MusicControl.mcInstance.muteComplete();
		}
		else
		{
			MusicControl.mcInstance.unmuteComplete();
		}

		UIControl.uiInstance.MusicBtnEnable();

		//Check for current player and collect info
		foreach (Player player in playerList)
		{
			if (player.current == true)
			{
				//Change text property of Text objects
				UIControl.uiInstance.playerNum.text = (playerList.IndexOf(player) + 1).ToString();
				UIControl.uiInstance.playerFinalScore.text = player.score.ToString();

				break;
			}
		}
	}

	public void ResetScoreTrack() //Resets player scores on scoreboard
	{
		foreach (Text text in UIControl.uiInstance.playerScoreTracks)
			text.text = "0";
	}

	public void RematchGame()   //Resets player status and returns to Ready
	{
		Debug.Log("Rematch - Resetting stats");

		ResetScoreTrack();

		foreach (Player player in playerList)
		{
			player.score = 0;

			if (player.current == true)
			{
				player.current = false;
			}
		}

		playerList[0].current = true;
	}

	public void ResetGame() //Resets the player settings and item object and returns to the Main Menu
	{
		Debug.Log("Finish - Resetting game");

		if(timerExists == true)
		{
			turnTimer.Stop();
			timerExists = false;
		}

		ResetScoreTrack();

		playerList.Clear();

		item = new Item("", "");
		item.ItemSetup();

		SettingsControl.stInstance.ResetAllSettings();
	}

	/*
	 * _____________________________________________________________________________________________________________________________________________________
	 * Game Time
	 */

	// Use this for initialization
	void Start ()
	{
		//If the gameObject has not been created, initialize the singleton (variable to reference its own class)
		//and set the object to not be destroyed
		if (objectCreated == false)
		{
			gmInstance = this;

			DontDestroyOnLoad(this.gameObject);
			objectCreated = true;

			Debug.Log("Awake: " + this.gameObject);
		}

		//Populate objektList and colorList at launch
		item.ItemSetup();

		//Ensure default settings at launch
		SettingsControl.stInstance.ResetAllSettings();
	}
	
	// Update is called once per frame
	void Update ()
	{
		//Check for status of timer
		if (timerFinished == true)
		{
			NextPlayer();
		}
	}
}
