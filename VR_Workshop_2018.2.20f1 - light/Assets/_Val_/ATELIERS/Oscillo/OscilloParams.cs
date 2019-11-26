using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OscilloParams : MonoBehaviour
{
    public float startValuePot1;
    public float startValuePot2;

    public float rotationPot1;
    public float rotationPot2;

    public VRTK.Controllables.PhysicsBased.VRTK_PhysicsRotator Manivelle1;
    public VRTK.Controllables.PhysicsBased.VRTK_PhysicsRotator Manivelle2;
    public bool isDone = false;

    //public OscilloScript OS;
    public Transform OS;

    public void Start()
    {
        //startValuePot1 = OS._speed;
        //startValuePot2 = OS._maxOscValue;

        Manivelle1.SetValue(36f);
        Manivelle2.SetValue(36f);
    }

    public void Update()
    {
        if (isDone == false)
        {
            OS.transform.localScale = new Vector3(1.5f, Manivelle1.GetValue() / 36f, 1f);
            OS.GetComponent<Graph>().offsetX = Manivelle2.GetValue() / 90f;
        }

        //OS._speed = startValuePot1 + rotationPot1;
        //OS._maxOscValue = startValuePot2 + rotationPot2;
    }
}
