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
	private int numofslots;
	public TileSlot[] slots;
 	
	public static int currentStreak = 1;
	public static bool inStreak = false;
	#endregion

	// Use this for initialization
	void Start () 
	{


	}
	public void Init()
	{
		currentStreak = 1;
		inStreak = false;

		Transform temptrans;
		GameObject slot;
		GameObject tile;
		numofslots = gameAnswer.Length;
		slots = new TileSlot[numofslots];
		for(int i = 0; i < gameAnswer.Length; i++)
		{
			slot = (GameObject) GameObject.Instantiate(slotPrefab,
			                       new Vector3(-offset + (50 * i), -50, 0),
			                              Quaternion.identity);
			temptrans = slot.transform;
			slot.transform.parent = this.gameObject.transform;
			slot.transform.localScale = new Vector3(0.75f,0.75f,1);
			slot.transform.localPosition = temptrans.position;
			slot.GetComponent<TileSlot>().correctLetter = gameAnswer.Substring(i,1);
			slots[i] = slot.GetComponent<TileSlot>();

			tile = (GameObject) GameObject.Instantiate(tilePrefab,
			            new Vector3(-offset + (50 * i),
			            50 + (20 * Random.value), 0),
			                           Quaternion.identity);
			temptrans = tile.transform;
			tile.transform.parent = this.gameObject.transform;
			tile.transform.localScale = temptrans.lossyScale;
			tile.transform.localPosition = temptrans.position;
			tile.GetComponent<Tile>().letter = gameAnswer.Substring(i,1);

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
		Debug.Log("Win: " + win);
	}
	public void StartWinCheck()
	{
		StartCoroutine("waitToCheckWin");
	}
	
}
