using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveFusible : MonoBehaviour {
    private ParticleSystem ps;
    public GameObject FusSnap;
    private vrtk.FusibleSnapped fs;

    // Use this for initialization
    void Start ()
    {
        ps = gameObject.GetComponent<ParticleSystem>();
        ps.Stop();
        ps.Clear();
        fs = FusSnap.GetComponent<vrtk.FusibleSnapped>();
    }
	
	// Update is called once per frame
	void Update ()
    {
		if (fs.snapped == true)
            ps.Play();
        else
        {
            ps.Stop();
            ps.Clear();
        }
    }
}
