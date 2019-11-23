using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrostArea : MonoBehaviour {

    public FrostEffect _frostEffect;


    private void OnTriggerStay(Collider col)
    {
        if (col.tag == "Player")
        {
            _frostEffect._isOnTrigger = true;
        }
    }

    private void OnTriggerExit(Collider col)
    {
        if (col.tag == "Player")
        {
            _frostEffect._isOnTrigger = false;
        }
    }
}
