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
		retPos = this.transform.localPosition;
	}
	public void OnRelease()
	{
		//Debug.Log("Released" + this.transform.localPosition);
//		if(!hasSlot)
//		{
//			retPos = startPos;
//		}
		TweenPosition.Begin(this.gameObject,0.2f,retPos);
		SendMessageUpwards("StartWinCheck");
	}
	public void FoundSlot(TileSlot tSlot)
	{
		slotPos = tSlot.transform.localPosition;
		retPos = slotPos;
		hasSlot = true;
	}
	public void LoseSlot()
	{
		//slotPos = tSlot.transform.localPosition;
		retPos = startPos;
		hasSlot = false;
	}

}
