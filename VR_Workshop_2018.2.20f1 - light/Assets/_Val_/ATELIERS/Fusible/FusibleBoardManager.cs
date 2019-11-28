using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FusibleBoardManager : MonoBehaviour {
    public vrtk.FusibleSnapped[] snappedFusible;
    public int snappedOnes = 0;
    public bool atelierFinished = false;
    public Player _playerManager;

    void Start ()
    {
		
    }

	void Update () {
        if (snappedOnes == snappedFusible.Length)
        {
            atelierFinished = true;
            _playerManager._changeRespawn(1);
        }
        else
        {
            atelierFinished = false;
        }


        /*for (int i = 0; i < snappedFusible.Length + 1; i++)
        {
            if (snappedFusible[i].snapped == true)
            {
                snappedOnes = i;
            }
        }*/
	}
}
