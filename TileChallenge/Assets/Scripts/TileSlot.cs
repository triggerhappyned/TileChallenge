using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TileSlot : MonoBehaviour 
{
	
	#region Variables
	public string correctLetter;
	public Tile placedTile;
	#endregion

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}

	void OnTriggerEnter(Collider col)
	{
		//Debug.Log("Entered");
		col.gameObject.GetComponent<Tile>().FoundSlot(this);
		placedTile = col.gameObject.GetComponent<Tile>();

	}
	void OnTriggerExit(Collider col)
	{
		//Debug.Log("Exited");
		col.gameObject.GetComponent<Tile>().LoseSlot();
		placedTile = null;
	}

}
