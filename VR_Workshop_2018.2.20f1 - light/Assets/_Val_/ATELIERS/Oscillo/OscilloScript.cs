using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OscilloScript : MonoBehaviour {
    public float oscValue = 0f;
    public float _speed = .5f;
    public float _maxOscValue = 2f;

    Vector3 originalPosition;

    // Use this for initialization
    void Start () {
        originalPosition = transform.position;
    }
	
	// Update is called once per frame
	void Update () {
        oscValue = Mathf.Sin(Time.time * _speed) * _maxOscValue / 100;
        transform.position = new Vector3(transform.position.x, originalPosition.y + oscValue, transform.position.z);
    }
}
