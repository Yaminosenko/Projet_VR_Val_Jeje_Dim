using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FourScript : MonoBehaviour {

    public Image _jauge;
    public Canvas _can;

    private float _maxJauge = 100;
    private float _currentJauge;
    private int _count = 0;

    private void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.tag == "Shovel")
        {
            Shovel _shovel = col.gameObject.GetComponentInParent<Shovel>();
            foreach (GameObject _coal in _shovel._coal)
            {
                _count++;
                _currentJauge += 2.5f;
                Debug.Log(_count);
            }
            _shovel.UnsnapCoal();
            _shovel._coal.Clear();
            _shovel._isSnap = false;

        }

        if (col.gameObject.tag == "coal")
        {
            _currentJauge += 2.5f;
            _count++;
           
        }
    }


    private void Update()
    {
        if (_currentJauge != 0)
        {

        }

        UpdateJauge();
    }

    void UpdateJauge()
    {
        float ratio = (float)_currentJauge / (float)_maxJauge;

        Debug.Log(ratio);
        Mathf.Clamp01(ratio);

        Vector3 newScale = _jauge.transform.localScale;
        newScale.y = ratio;
        _jauge.transform.localScale = newScale;


    }
}
