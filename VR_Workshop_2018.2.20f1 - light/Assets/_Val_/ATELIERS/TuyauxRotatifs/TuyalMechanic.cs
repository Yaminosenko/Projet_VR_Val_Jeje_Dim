using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TuyalMechanic : MonoBehaviour
{
	public ParticleSystem[] ps;
	public Transform[] tuyals;
	public int tuyalOnX = 0;
	public bool atelierDone = false;

	void Start () {
		
	}

	void Update ()
	{
		tuyalOnX = tuyals[0].GetComponent<RotateTuyal>().onXint +
					tuyals[1].GetComponent<RotateTuyal>().onXint +
					tuyals[2].GetComponent<RotateTuyal>().onXint +
					tuyals[3].GetComponent<RotateTuyal>().onXint +
					tuyals[4].GetComponent<RotateTuyal>().onXint;
		
		if (tuyalOnX == 5)
		{
			DoVFX();
			atelierDone = true;
		}
		else
		{
			UndoVFX();
			atelierDone = false;
		}
	}

	public void DoVFX ()
	{
		foreach (ParticleSystem p in ps)
		{
			p.Play();
		}
	}

	public void UndoVFX ()
	{
		foreach (ParticleSystem p in ps)
		{
			p.Stop();
			p.Clear();
		}
	}
}
