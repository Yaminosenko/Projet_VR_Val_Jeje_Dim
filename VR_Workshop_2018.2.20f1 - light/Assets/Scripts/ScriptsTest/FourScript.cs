using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FourScript : MonoBehaviour {

    public Image _jauge;
    public Canvas _can;

    private float _maxJauge = 100;
    private float _burnCoal = 0;
    [SerializeField] private float _currentJauge;
    [SerializeField] private float _currentDecrease;
    [SerializeField] private float _currentIncrease;
    private int _count = 0;
    private int _numberOfCoal = 0;
    private bool _isHot = false;

    private void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.tag == "Shovel")
        {
            Shovel _shovel = col.gameObject.GetComponentInParent<Shovel>();
            foreach (GameObject _coal in _shovel._coal)
            {
                _count++;
                _currentJauge += 2.5f;
                _numberOfCoal++;
                //Debug.Log(_count);
            }
            _shovel.UnsnapCoal();
            _shovel._coal.Clear();
            _shovel._isSnap = false;

        }

        //if (col.gameObject.tag == "coal")
        //{
        //    _currentJauge += 2.5f;
        //    _count++;
           
        //}
    }


    private void Update()
    {
        if (_currentJauge != 0 && _currentJauge < 25)
        {
            _currentJauge -= 6f * Time.deltaTime;
        }
        else if (_currentJauge >= 25 && _currentJauge < 50)
        {
            _currentJauge -= 4 * Time.deltaTime;
            //Debug.Log("ui");
        }
        else if(_currentJauge >= 50 && _currentJauge < 75)
        {
            //_currentJauge
        }


        if(_burnCoal != 0)
        {
            _burnCoal -= 1 * Time.deltaTime;
            _currentJauge += _currentIncrease * Time.deltaTime;
        }


       

        UpdateJauge();
    }

    void UpdateJauge()
    {
        float ratio = (float)_currentJauge / (float)_maxJauge;

        //Debug.Log(ratio);
        Mathf.Clamp01(ratio);

        Vector3 newScale = _jauge.transform.localScale;
        newScale.y = ratio;
        _jauge.transform.localScale = newScale;


    }

    
}
