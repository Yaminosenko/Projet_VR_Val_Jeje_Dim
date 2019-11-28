using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateTuyal : MonoBehaviour
{
    public Transform[] manivelle;
    public float _angleY;

    public int onXint = 0;

	void Update ()
    {
        if (manivelle.Length == 1)
        {
            _angleY = manivelle[0].GetComponent<VRTK.Controllables.ArtificialBased.VRTK_ArtificialRotator>().GetValue();
        }
        else if (manivelle.Length == 2)
        {
            _angleY = manivelle[0].GetComponent<VRTK.Controllables.ArtificialBased.VRTK_ArtificialRotator>().GetValue() +
                    manivelle[1].GetComponent<VRTK.Controllables.ArtificialBased.VRTK_ArtificialRotator>().GetValue();
        }
        else if (manivelle.Length == 3)
        {
            _angleY = manivelle[0].GetComponent<VRTK.Controllables.ArtificialBased.VRTK_ArtificialRotator>().GetValue() +
                    manivelle[1].GetComponent<VRTK.Controllables.ArtificialBased.VRTK_ArtificialRotator>().GetValue() +
                    manivelle[2].GetComponent<VRTK.Controllables.ArtificialBased.VRTK_ArtificialRotator>().GetValue();
        }
        transform.localEulerAngles = new Vector3(0f, _angleY, 0f);
    }

    public void OnTriggerStay (Collider col)
    {
        if (col.tag == "tuyal")
        {
            onXint = 1;
        }
    }

    public void OnTriggerExit (Collider col)
    {
        if (col.tag == "tuyal")
        {
            onXint = 0;
        }
    }
}
