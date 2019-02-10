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
 * Class to create 'Player' object
 * Player
 */

public class Player
{

	/*
	 * _____________________________________________________________________________________________________________________________________________________
	 * Attributes
	 */

	public string pname { get; set; }
	public int score { get; set; }
	public bool current { get; set; }
	private bool winner { get; set; }

	/*
	 * _____________________________________________________________________________________________________________________________________________________
	 * Constructor
	 */

	public Player(string pname, int score, bool current, bool winner)
	{
		this.pname = pname;
		this.score = score;
		this.current = current;
		this.winner = winner;
	}

	/*
	 * _____________________________________________________________________________________________________________________________________________________
	 * Behaviors
	 */

	public override string ToString() //Debug string with relevant attributes
	{
		string print = " Score: " + score + " Winner: " + winner + " Current: " + current;
		return print;
	}

	public bool ScoreCheck() //Check if the player has a winning score
	{
		if (score >= SettingsControl.stInstance.scoreThreshold)
		{
			winner = true;
			return winner;
		}
		else
		{
			winner = false;
			return winner;
		}
	}

	public int ScoreAdd() //Add 50 points to player score
	{
		score += 50;
		return score;
	}

	public int ScoreSub() //Subtract 50 points from player score
	{
		score -= 25;
		return score;
	}
}
