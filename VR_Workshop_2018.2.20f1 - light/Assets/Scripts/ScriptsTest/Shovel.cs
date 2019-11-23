using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shovel : MonoBehaviour {

    public GameObject _prefabCoal;
    public GameObject[] _offsets;
    public List<GameObject> _coal = new List<GameObject>();
    public bool _isSnap = false;

    private Vector3 previousPosition;
    private float speed;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        //if (Input.GetKeyDown(KeyCode.P))
        //{
        //    _coalSnap();
        //    _isSnap = true;
        //}
        //if (Input.GetKeyDown(KeyCode.M))
        //{
        //    UnsnapCoal();
        //    _coal.Clear();
        //    _isSnap = false;
        //}

    }

   public void _coalSnap()
    {
        for (int i = 0; i < Random.Range(3,_offsets.Length); i++)
        {
            //Instantiate GameObject _coalChild = Instantiate(_coal, transform.position, _cone);
            GameObject _coalChild = Instantiate(_prefabCoal, _offsets[i].transform.position, _offsets[i].transform.rotation);
            _coalChild.transform.parent = gameObject.transform;
            _coal.Add(_coalChild);
           // _coalChild.GetComponent<FixedJoint>().connectedBody = gameObject.GetComponent<Rigidbody>();

            _coalChild.GetComponent<CharacterJoint>().connectedBody = gameObject.GetComponent<Rigidbody>();
        }
    }

    public void UnsnapCoal()
    {
        foreach (GameObject _coalChild in _coal)
        {
            //_coalChild.GetComponent<FixedJoint>().breakForce = 0;
            //_coalChild.GetComponent<FixedJoint>().connectedBody = null;
            _coalChild.GetComponent<CharacterJoint>().breakForce = 0;
            _coalChild.GetComponent<CharacterJoint>().connectedBody = null;
            Destroy(_coalChild.GetComponent<CharacterJoint>());
            Destroy(_coalChild, 2f);
        }
    }

    public float GetSpeed()
    {
        return speed;
    }
}
