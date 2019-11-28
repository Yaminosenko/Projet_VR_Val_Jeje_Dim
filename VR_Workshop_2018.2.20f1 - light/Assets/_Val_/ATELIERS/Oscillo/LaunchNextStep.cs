using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaunchNextStep : MonoBehaviour 
{
	FusibleBoardManager FBM;
	OscilloWinCondition OWC;
	public GameObject objToEnable;
	public GameObject objToEnable2;

	void Start () {
		if (gameObject.GetComponent<FusibleBoardManager>() != null)
		{
			FBM = gameObject.GetComponent<FusibleBoardManager>();
		}
		if (gameObject.GetComponent<OscilloWinCondition>() != null)
		{
			OWC = gameObject.GetComponent<OscilloWinCondition>();
		}
	}
	
	void Update () {
		if (FBM != null && FBM.atelierFinished == true)
		{
			objToEnable.SetActive(true);
			gameObject.GetComponent<LaunchNextStep>().enabled = false;
            if (objToEnable2 != null)
            {
                objToEnable2.SetActive(true);
            }
        }
		if (OWC != null && OWC.atelierDone == true)
		{
			objToEnable.SetActive(true);
			gameObject.GetComponent<LaunchNextStep>().enabled = false;
		}

        
	}
}
