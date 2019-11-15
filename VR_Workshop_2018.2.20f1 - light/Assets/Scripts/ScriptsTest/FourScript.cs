using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FourScript : MonoBehaviour {

    public Image _jauge;
    public Canvas _can;

    private void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.tag == "Shovel")
        {
            col.gameObject.GetComponentInParent<Shovel>().UnsnapCoal();
            col.gameObject.GetComponentInParent<Shovel>()._coal.Clear();
            col.gameObject.GetComponentInParent<Shovel>()._isSnap = true;
        }

        if (col.gameObject.tag == "coal")
        {

        }
    }


    private void Update()
    {
        
    }
}
