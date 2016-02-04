using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class VictoryFireworks : MonoBehaviour 
{
	
	#region Variables
	public List<ParticleSystem> particles = new List<ParticleSystem>();

	#endregion

	// Use this for initialization
	public void ActivateVictory()
	{
		//StartCoroutine("BeginVictory");
		foreach(ParticleSystem e in particles)
		{
			e.Play();
		}
	}
	public void StopVictory()
	{
		foreach(ParticleSystem e in particles)
		{
			e.Stop();
		}
	}
	IEnumerator BeginVictory()
	{

		foreach(ParticleSystem e in particles)
		{
			e.Play();
		}
		yield return new WaitForSeconds(4.0f);

		foreach(ParticleSystem e in particles)
		{
			e.Stop();
		}
	}
}
