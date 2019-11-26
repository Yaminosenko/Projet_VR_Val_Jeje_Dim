using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartAngle : MonoBehaviour {

    [SerializeField] private Vector3 rotationVector;// = new Vector3(0, 36, 0);

    void Start ()
    {    
        Quaternion rotation = Quaternion.Euler(rotationVector);
        transform.localRotation = Quaternion.Slerp(transform.rotation, rotation, 360);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
