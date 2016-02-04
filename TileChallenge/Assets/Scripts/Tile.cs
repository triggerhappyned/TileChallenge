using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Tile : MonoBehaviour 
{
	
	#region Variables
	public string letter;
	public UILabel mylabel;
	public Vector3 startPos;
	private Vector3 retPos;
	private Vector3 slotPos;
	public bool hasSlot;

	public TileSlot myslot;
	public PointBurst myPointBurst;
	#endregion

	// Use this for initialization
	void Start () 
	{
		Initialize();
	}
	void Initialize()
	{
		if(letter != "")
		{
			mylabel.text = letter;

		}
		startPos = transform.localPosition;
	}
	// Update is called once per frame
	void Update () 
	{

	}

	void OnTriggerEnter(Collider other) 
	{

	}
	void OnTriggerExit(Collider other) 
	{
		
	}
	public void PickedUp()
	{
		//Debug.Log("Picked Up" + this.transform.position);
		retPos = startPos;
		if(myslot)
		{
			if(myslot.correctLetter != letter)
			{
				myslot.placedTile = null;
				myslot = null;
				hasSlot = false;
				retPos = startPos;
			}
		}
	}
	public void OnRelease()
	{
		//Debug.Log("Released" + this.transform.localPosition);
		if(hasSlot && !myslot.placedTile)
		{
			myslot.placedTile = this;
			myslot.EndHoverTween();
			if(myslot.correctLetter == letter)
			{
				this.GetComponent<UIDragObject>().enabled = false;
				this.GetComponent<UIButtonScale>().enabled = false;

				myPointBurst.Activate(TileBoard.currentStreak);
				TileBoard.inStreak = true;
				if(TileBoard.currentStreak < 10)
				{
					TileBoard.currentStreak *= 2;
				}

			}
			else
			{
				TileBoard.inStreak = false;
				TileBoard.currentStreak = 1;
				myPointBurst.ActivateFail();
			}
		}
		TweenPosition.Begin(this.gameObject,0.2f,retPos);

		SendMessageUpwards("StartWinCheck");

	}
	public void FoundSlot(TileSlot tSlot)
	{

		if(!tSlot.placedTile)
		{
			if(myslot)
			{
				myslot.EndHoverTween();
			}
			slotPos = tSlot.transform.localPosition;
			retPos = slotPos;
			hasSlot = true;
			myslot = tSlot;
			myslot.BeginHoverTween();
		}

	}
	public void LoseSlot(TileSlot tslot)
	{
		//slotPos = tSlot.transform.localPosition;

		tslot.EndHoverTween();
		if(myslot == tslot)
		{
			retPos = startPos;
			hasSlot = false;
			myslot = null;
		}
	}

}
