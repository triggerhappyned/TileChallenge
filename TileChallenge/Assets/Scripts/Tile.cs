using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Tile : MonoBehaviour 
{
	
	#region Variables
	public string letter;
	public UILabel mylabel;

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
			Debug.Log(letter);
		}
	}
	// Update is called once per frame
	void Update () 
	{

	}

	void OnTriggerEnter(Collider other) 
	{

	}
	public void PickedUp()
	{
		Debug.Log("Picked Up");
	}
	public void OnRelease()
	{
		Debug.Log("Released");
	}

}
