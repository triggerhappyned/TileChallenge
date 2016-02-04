using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TileSlot : MonoBehaviour 
{
	
	#region Variables
	public string correctLetter;
	public Tile placedTile;
	public GameObject bg;
	#endregion

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}

	public void BeginHoverTween()
	{
		if(!placedTile)
			TweenScale.Begin(bg,0.1f,new Vector3(60f,60f,1));
	}
	public void EndHoverTween()
	{
		TweenScale.Begin(bg,0.1f,new Vector3(50f,50f,1));
	}
	void OnTriggerEnter(Collider col)
	{
		col.gameObject.GetComponent<Tile>().FoundSlot(this);
	}
	void OnTriggerExit(Collider col)
	{
		col.gameObject.GetComponent<Tile>().LoseSlot(this);
	}
	void OnTriggerStay(Collider col)
	{
		if(!placedTile && !col.gameObject.GetComponent<Tile>().hasSlot)
		{
			col.gameObject.GetComponent<Tile>().FoundSlot(this);
		}
	}

}
