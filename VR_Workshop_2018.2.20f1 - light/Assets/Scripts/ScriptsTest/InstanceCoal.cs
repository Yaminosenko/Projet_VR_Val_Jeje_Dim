using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstanceCoal : MonoBehaviour {

    public GameObject _coal;
    public int _max = 20;
    private int _currentCoal;

    private void Update()
    {
        //Quaternion _cone = new Quaternion(0, Random.Range(0, 360), Random.Range(0, 30), 0);
        //if (_currentCoal < _max)
        //{
        //    GameObject _coalChild = Instantiate(_coal, transform.position, _cone);
        //    _currentCoal++;
        //    _coalChild.transform.parent = gameObject.transform;
        //}

        
    }
    private void OnTriggerEnter(Collider col)
    {
        if(col.transform.tag == "Shovel")
        {

        }
    }
}
