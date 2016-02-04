using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TileBoard : MonoBehaviour 
{
	
	#region Variables
	public GameObject tilePrefab;
	public GameObject slotPrefab;
	public string gameAnswer;
	public int offset;
	public int numofslots;
	public int newLineOn;
	private TileSlot[] slots;
	public static int currentStreak = 1;
	public static bool inStreak = false;
	private List<Tile> temptiles = new List<Tile>();

	public TileBoard nextLevel;
	public GameObject NextLvlButton;
	#endregion

	// Use this for initialization
	void Start () 
	{


	}
	// initiallizes game board with spaces and new line if required. 
	public void InitWithSpaces()
	{
		currentStreak = 1;
		inStreak = false;
		
		Transform temptrans;
		GameObject slot;
		GameObject tile;
		numofslots = 0;
		for(int i = 0; i < gameAnswer.Length; i++)
		{
			if(gameAnswer.Substring(i,1) != " ")
			{
				numofslots++;
			}
		}

		slots = new TileSlot[numofslots];

		int spaceOffset = 0;
		int lineOffset = 0;
		int slotIndex = 0;
		int space = 0;
		for(int i = 0; i < gameAnswer.Length; i++)
		{
			if(gameAnswer.Substring(i,1) != " ")
			{
				
				slot = (GameObject) GameObject.Instantiate(slotPrefab,
				                                           new Vector3(-offset + spaceOffset + (50 * slotIndex),
				            								-50 + lineOffset, 0),
				                                           Quaternion.identity);
				temptrans = slot.transform;
				slot.transform.parent = this.gameObject.transform;
				slot.transform.localScale = new Vector3(0.75f,0.75f,1);
				slot.transform.localPosition = temptrans.position;
				slot.GetComponent<TileSlot>().correctLetter = gameAnswer.Substring(i,1);
				slots[slotIndex] = slot.GetComponent<TileSlot>();
				
				tile = (GameObject) GameObject.Instantiate(tilePrefab,
				                                           new Vector3(-offset + (50 * slotIndex),
				            								50 + lineOffset, 0),
				                                           Quaternion.identity);
				temptrans = tile.transform;
				tile.transform.parent = this.gameObject.transform;
				tile.transform.localScale = temptrans.lossyScale;
				tile.transform.localPosition = temptrans.position;
				tile.GetComponent<Tile>().letter = gameAnswer.Substring(i,1);
				
				temptiles.Add(tile.GetComponent<Tile>());
				slotIndex++;
			}
			else
			{
				space++;
				spaceOffset += 30;
				if(space == newLineOn)
				{
					spaceOffset = -450;
					lineOffset += -70;
					space = 0;

				}
			}
		}
		// this will sort the tiles and place them above the game board.
		// tiles are placed in alphabetical order for simplicity. 
		temptiles.Sort((x, y) => x.letter.CompareTo(y.letter));
		int tempindex = 0;
		int newlineoffset = 0;
		spaceOffset = 0;
		foreach(Tile t in temptiles)
		{
			if(tempindex > numofslots/2 && numofslots > 10 ) 
			{
				newlineoffset = -60;
				spaceOffset = -450;
			}
			t.transform.localPosition = new Vector3(-offset + spaceOffset + (50 * tempindex), 
			                                        80 + newlineoffset, 0);
			tempindex++;

		}
	}
	// this is a win check that is preformed every time a tile is placed.
	public bool CheckForWin()
	{
		string tempString = "";
		bool win = false;
	
		for(int i = 0; i < numofslots; i++)
		{

			if(slots[i].placedTile != null)
			{
				tempString += slots[i].placedTile.letter;
			}
		}
		//Debug.Log(tempString);
		string tempAnswer = "";
		for(int i = 0; i < gameAnswer.Length; i++)
		{
			if(gameAnswer.Substring(i,1) != " ")
			{
				tempAnswer += gameAnswer.Substring(i,1);
			}
		}
		//Debug.Log(tempAnswer);
		if(tempString == tempAnswer)
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
		Debug.Log("Win: " + win);
		if(win)
		{
			GameObject fireworks = GameObject.FindGameObjectWithTag("Fireworks");
			fireworks.GetComponent<VictoryFireworks>().ActivateVictory();

			yield return new WaitForSeconds(4.0f);
			if(NextLvlButton)
			{
				NextLvlButton.SetActive(true);
			}


		}

	}
	public void StartWinCheck()
	{
		StartCoroutine("waitToCheckWin");
	}
	//starts next level. stops firework celebration.
	public void StartNextLevel()
	{
		GameObject fireworks = GameObject.FindGameObjectWithTag("Fireworks");
		fireworks.GetComponent<VictoryFireworks>().StopVictory();

		TweenPosition.Begin(this.gameObject, 0.9f, new Vector3(0,-300,0));
		nextLevel.InitWithSpaces();
		
		TweenPosition.Begin(nextLevel.gameObject, 1.5f, new Vector3(0,0,0));
	}
	
}
