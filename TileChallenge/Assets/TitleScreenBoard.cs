using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TitleScreenBoard : MonoBehaviour 
{
	
	#region Variables
	public Tile pTile;
	public Tile lTile;
	public Tile aTile; 
	public Tile yTile;
	public string gameAnswer;
	private int numofslots;
	public TileSlot[] slots;
	
	public TileBoard basicMode;
	#endregion
	
	// Use this for initialization
	void Start () 
	{
		slots[1].placedTile = lTile;
		slots[2].placedTile = aTile;
		slots[3].placedTile = yTile;

		lTile.FoundSlot(slots[1]);
		aTile.FoundSlot(slots[2]);
		yTile.FoundSlot(slots[3]);

		TweenPosition.Begin(lTile.gameObject, 1.0f, slots[1].transform.localPosition);
		TweenPosition.Begin(aTile.gameObject, 1.0f, slots[2].transform.localPosition);
		TweenPosition.Begin(yTile.gameObject, 1.0f, slots[3].transform.localPosition);
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

		//yield return new WaitForSeconds(0.5f);
		if(win)
		{

			TweenPosition.Begin(this.gameObject, 0.9f, new Vector3(0,-300,0));
			basicMode.Init();
			yield return new WaitForSeconds(0.1f);

			TweenPosition.Begin(basicMode.gameObject, 1.5f, new Vector3(0,0,0));
		}

		yield return new WaitForSeconds(1.2f);
	}
	public void StartWinCheck()
	{
		StartCoroutine("waitToCheckWin");
	}
}
