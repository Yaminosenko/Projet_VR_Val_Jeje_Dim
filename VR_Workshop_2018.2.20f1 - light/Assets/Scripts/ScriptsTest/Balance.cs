using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class Balance : MonoBehaviour {

    public Transform _aiguille;
    public float _currentMasse = 0;
    public float _masseMax = 100;
    private float _count = 0;
    private float _mass;
    public GameObject objToEnable;
    public Player _playerManager;


    private void OnTriggerEnter(Collider col)
    {
       
        if (col.gameObject.GetComponent<Rigidbody>() != null)
        {
            _count++;
            _mass = col.gameObject.GetComponent<Rigidbody>().mass;
            col.gameObject.GetComponent<VRTK_InteractableObject>().isGrabbable = false;
        }

        if(col.gameObject.tag == "Corps")
        {
            _count++;
            _mass = 30;
            col.gameObject.GetComponent<VRTK_InteractableObject>().isGrabbable = false;
        }
    }

    private void Update()
    {
        _currentMasse = Mathf.Clamp(_currentMasse, 0, _masseMax);
        if (_count > 0)
        {
            _count -= 1 * Time.deltaTime * 10;
            _currentMasse += _mass * Time.deltaTime * 10;
        }

        if(_currentMasse >= 99)
        {
            objToEnable.SetActive(true);
            _playerManager._changeRespawn(2);
        }

        UpdateJauge();
    }

    void UpdateJauge()
    {
        float ratio = (float)_currentMasse / (float)_masseMax;

        
        Mathf.Clamp01(ratio);
        Vector3 newScale = _aiguille.transform.localPosition;
        newScale.x = ratio;
        _aiguille.transform.localPosition = new Vector3(newScale.x - 0.5f, newScale.y, newScale.z);
    }
}
