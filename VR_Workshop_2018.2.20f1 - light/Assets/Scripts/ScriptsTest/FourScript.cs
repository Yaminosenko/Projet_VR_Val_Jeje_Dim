using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using VRTK.Controllables.ArtificialBased;


public class FourScript : MonoBehaviour {

    public Image _jauge;
    public Image _vapeur;
    public Canvas _can;
    public VRTK_ArtificialRotator _levier;

    private float _maxJauge = 100;
    private float _burnCoal = 0;
    [SerializeField] private float _currentJauge;
    [SerializeField] private float _currentJaugeVapeur;
    [SerializeField] private float _currentDecrease;
    [SerializeField] private float _initialDeacrease;
    [SerializeField] private float _currentIncrease;
    private int _count = 0;
    //private int _numberOfCoal = 0;
    private bool _isHot = false;
    private bool _vapeurOut = false;



    private void Awake()
    {
        _currentDecrease = _initialDeacrease;
    }

    private void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.tag == "Shovel")
        {
            Shovel _shovel = col.gameObject.GetComponentInParent<Shovel>();
            foreach (GameObject _coal in _shovel._coal)
            {
                _count++;
                //_currentJauge += 2.5f;
                _burnCoal++;
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

        
        if (_levier.GetControlInteractableObject().IsGrabbed() == false)
        {
            _levier.SetValue(Mathf.Lerp(_levier.GetValue(), 0, Time.deltaTime * 4));
        }

        if (_levier.GetValue() >= 75)
        {
            _vapeurOut = true;
        }

        Jauge();
        UpdateJauge();
        UpdateJaugeVapeur();
    }


    void Jauge()
    {
        if (_currentJauge >= 0 && _currentJauge < 25)
        {
            _currentJauge -= (_currentDecrease + 3) * Time.deltaTime;
        }
        else if (_currentJauge >= 25 && _currentJauge < 50)
        {
            _currentJauge -= (_currentDecrease + 2) * Time.deltaTime;
            _currentJaugeVapeur += _currentDecrease * Time.deltaTime;
            //Debug.Log("ui");
        }
        else if (_currentJauge >= 50 && _currentJauge < 75)
        {
            _currentJaugeVapeur += 4 * Time.deltaTime;
            _currentJauge -= _currentDecrease * Time.deltaTime;
        }
        else if (_currentJauge >= 75)
        {
            _currentJaugeVapeur += 6 * Time.deltaTime;
            _currentJauge -= (_currentDecrease ) * Time.deltaTime;
        }


        if (_burnCoal > 0)
        {
            _burnCoal -= 1 * Time.deltaTime;
            _currentJauge += _currentIncrease * Time.deltaTime;
        }

        if (_currentJaugeVapeur > 25)
        {
            _currentDecrease = _initialDeacrease /  (_currentJaugeVapeur / 30);

        }
        else
        {
            _currentDecrease = _initialDeacrease;
        }

        if(_vapeurOut == true)
        {
            _currentJaugeVapeur -= _maxJauge * Time.deltaTime;
            _currentJauge -= 10 * Time.deltaTime;

            if(_currentJaugeVapeur <= 0)
            {
                _currentJaugeVapeur = 0;
                _vapeurOut = false;
            }
        }

        _currentJauge = Mathf.Clamp(_currentJauge, 0, 100);
        _currentJaugeVapeur = Mathf.Clamp(_currentJaugeVapeur, 0, 100);
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

    void UpdateJaugeVapeur()
    {
        float ratio = (float)_currentJaugeVapeur / (float)_maxJauge;

        //Debug.Log(ratio);
        Mathf.Clamp01(ratio);

        Vector3 newScale = _vapeur.transform.localScale;
        newScale.y = ratio;
        _vapeur.transform.localScale = newScale;
    }

}
