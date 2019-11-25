using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrostArea : MonoBehaviour {

    public FrostEffect _frostEffect;
    public Player _player;


    private void OnTriggerStay(Collider col)
    {
        if (col.tag == "Player")
        {
            _frostEffect._isOnTrigger = true;
            _player._isInFrostArea = true;
        }
    }

    private void OnTriggerExit(Collider col)
    {
        if (col.tag == "Player")
        {
            _frostEffect._isOnTrigger = false;
            _player._isInFrostArea = false;
        }
    }
}
