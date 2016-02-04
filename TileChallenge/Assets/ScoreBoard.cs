using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ScoreBoard : MonoBehaviour 
{
	
	#region Variables
	public int score = 0;
	#endregion

	public void UpdateScore(int add)
	{
		score += add;
		this.GetComponent<UILabel>().text = "00000".Substring(0, 5 - score.ToString().Length) + score;
	}
}
