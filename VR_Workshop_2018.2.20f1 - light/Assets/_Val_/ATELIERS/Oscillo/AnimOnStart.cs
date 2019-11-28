using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimOnStart : MonoBehaviour {
	public Animation anim;
    public bool _rewind = false;
	// Use this for initialization
	void Start () {
		anim.Play();
        
	}
	
	// Update is called once per frame
	void Update () {
		if(_rewind == true)
        {
            Debug.Log("uuii");
            anim.Rewind();
            //this.gameObject.SetActive(false);
        }
	}
}
