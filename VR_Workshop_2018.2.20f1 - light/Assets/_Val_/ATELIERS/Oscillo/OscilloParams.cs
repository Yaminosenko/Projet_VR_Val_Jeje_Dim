using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OscilloParams : MonoBehaviour
{
    //public float startValuePot1;
    //public float startValuePot2;

    //public float rotationPot1;
    //public float rotationPot2;

    public float debugX;
    public float debugY;

    public VRTK.Controllables.PhysicsBased.VRTK_PhysicsRotator Manivelle1;
    public VRTK.Controllables.PhysicsBased.VRTK_PhysicsRotator Manivelle2;
    public bool isDone = false;

    //public OscilloScript OS;
    public Transform OS;

    public void Start()
    {
        //startValuePot1 = OS._speed;
        //startValuePot2 = OS._maxOscValue;

        Manivelle1.SetValue(360f / 4f); //Y
        Manivelle2.SetValue(360f / 7f);  //X
    }

    public void Update()
    {
        if (isDone == false)
        {
            float xValue = Manivelle2.GetValue() / 36f;
            float yValue = Manivelle1.GetValue() / 36f;
            //OS.transform.localScale = new Vector3(1.5f, Manivelle1.GetValue() / 36f, 1f);
            if (xValue < 1.4f)
                xValue = 1.4f;
            if (yValue < 0.2f)
                yValue = 0.2f;
            if (yValue > 1.8f)
                yValue = 1.8f;

            OS.transform.localScale = new Vector3(xValue, yValue, 1f);

            //OS.GetComponent<Graph>().offsetX = Manivelle2.GetValue() / (36f * 5);
            debugY = yValue;
            debugX = xValue;
        }

        //OS._speed = startValuePot1 + rotationPot1;
        //OS._maxOscValue = startValuePot2 + rotationPot2;
    }
}
