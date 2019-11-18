using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shovel : MonoBehaviour {

    public GameObject _prefabCoal;
    public GameObject[] _offsets;
    public List<GameObject> _coal = new List<GameObject>();
    public bool _isSnap = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.P))
        {
            _coalSnap();
            _isSnap = true;
        }
        if (Input.GetKeyDown(KeyCode.M))
        {
            UnsnapCoal();
            _coal.Clear();
            _isSnap = false;
        }
	}

   public void _coalSnap()
    {
        for (int i = 0; i < _offsets.Length; i++)
        {
            //Instantiate GameObject _coalChild = Instantiate(_coal, transform.position, _cone);
            GameObject _coalChild = Instantiate(_prefabCoal, _offsets[i].transform.position, _offsets[i].transform.rotation);
            _coalChild.transform.parent = gameObject.transform;
            _coal.Add(_coalChild);
            _coalChild.GetComponent<FixedJoint>().connectedBody = gameObject.GetComponent<Rigidbody>();
        }
    }

    public void UnsnapCoal()
    {
        foreach (GameObject _coalChild in _coal)
        {
            _coalChild.GetComponent<FixedJoint>().breakForce = 0;
            _coalChild.GetComponent<FixedJoint>().connectedBody = null;
            Destroy(_coalChild, 2f);
        }
    }
}
