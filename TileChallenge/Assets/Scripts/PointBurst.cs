using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PointBurst : MonoBehaviour 
{
	
	#region Variables

	#endregion

	public void Activate(int points)
	{
		this.GetComponent<UILabel>().text = "+" + points;
		this.gameObject.SetActive(true);

		StartCoroutine("Burst");
	}
	public void ActivateFail()
	{
		this.GetComponent<UILabel>().text = "Nope";
		this.gameObject.SetActive(true);
		StartCoroutine("Burst");
	}
	IEnumerator Burst()
	{
		yield return new WaitForSeconds(0.3f);
		this.GetComponent<UILabel>().enabled = true;

		TweenPosition.Begin(this.gameObject, 01.0f, new Vector3( 0, 100, 0));

		yield return new WaitForSeconds(1.0f);

		this.transform.localPosition = Vector3.zero;
		this.GetComponent<UILabel>().enabled = false;
		this.gameObject.SetActive(false);
	}
}
