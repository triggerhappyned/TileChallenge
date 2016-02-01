﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TileBoard : MonoBehaviour 
{
	
	#region Variables
	public bool isTitle;
	public GameObject tilePrefab;
	public GameObject slotPrefab;
	public string gameAnswer;
	private int numofslots;
	public TileSlot[] slots;
 	

	#endregion

	// Use this for initialization
	void Start () 
	{
		numofslots = gameAnswer.Length;
		for(int i = 0; i < gameAnswer.Length; i++)
		{
			//GameObject.Instantiate(slotPrefab,new Vector3())
		}

	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}
	public bool CheckForWin()
	{
		string tempString = "";
		bool win = false;
		for(int i = 0; i < gameAnswer.Length; i++)
		{

			if(slots[i].placedTile != null)
			{
				tempString += slots[i].placedTile.letter;
			}
		}
		Debug.Log(tempString);
		if(tempString == gameAnswer)
		{
			win = true;
		}
		return win;
	}
	public IEnumerator waitToCheckWin()
	{
		bool win;
		yield return new WaitForSeconds(0.5f);
		win = CheckForWin();
		Debug.Log(win);
	}
	public void startWinCheck()
	{
		StartCoroutine("waitToCheckWin");
	}
}
