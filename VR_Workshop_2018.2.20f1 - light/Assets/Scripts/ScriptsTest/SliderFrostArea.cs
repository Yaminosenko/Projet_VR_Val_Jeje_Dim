using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using VRTK.Controllables.ArtificialBased;


public class SliderFrostArea : MonoBehaviour {

    public VRTK_ArtificialSlider[] _slider1;
    public VRTK_ArtificialSlider[] _slider2;
    public VRTK_ArtificialSlider[] _slider3;

    private List<VRTK_ArtificialSlider[]> _listGoupe = new List<VRTK_ArtificialSlider[]>(); 
    private VRTK_ArtificialSlider[] _evryGroup;

    public bool[] _isPull;

    //public bool _sliderBool1;
    //public bool _sliderBool2;
    //public bool _sliderBool3;

    public bool[] _sliderBool;


    //private bool _doubleTrue1 = false;
    //private bool _doubleTrue2 = false;
    //public bool[] _isPull2;
    //public bool[] _isPull3;

    public GameObject[] _doors;
    public GameObject[] _light;

    public Material m_green;
    public Material m_red;
    private Renderer _lightRenderer;

    private int _arraySlider = 0;

    private void Awake()
    {
        _listGoupe.Add(_slider1);
        _lightRenderer = _light[0].GetComponent<Renderer>();
        //_listGoupe.Add(_slider2);
        //_listGoupe.Add(_slider3);

        //_listGoupe.ToArray(_evryGroup);
    }


    private void Update()
    {
        SliderManager();


        if (_isPull[0] == true && _isPull[1] == true)
        {
            
            //_doors[_arraySlider].transform.position = new Vector3(_doors[_arraySlider].transform.position.x, 5, _doors[_arraySlider].transform.position.z);
            _lightRenderer.material = m_green;
        }
        else
        {
            //_doors[_arraySlider].transform.position = new Vector3(_doors[_arraySlider].transform.position.x, 0.89f, _doors[_arraySlider].transform.position.z);
            _lightRenderer.material = m_red;
        }


        //for (int i = 0; i < _isPull.Length; i++)
        //{
        //    if (_isPull[i] == true)
        //    {
        //        _doors[_arraySlider].transform.position = new Vector3(_doors[_arraySlider].transform.position.x,5, _doors[_arraySlider].transform.position.z);
        //    }
        //}
    }


    void SliderManager()
    {
        foreach (VRTK_ArtificialSlider[] slider in _listGoupe)
        {
            for (int i = 0; i < slider.Length; i++)
            {
                if (slider[i] != null)
                {
                    float _value = slider[i].GetValue();

                    if (_value >= 0.35f)
                    {
                        _isPull[i] = true;
                    }
                    else
                    {
                        _isPull[i] = false;
                    }

                    //_isPull[i] = _value >= 0.35f ? true : false;


                    if (slider[i].GetControlInteractableObject().IsGrabbed() == false)
                    {
                        slider[i].SetValue(Mathf.Lerp(slider[i].GetValue(), 0, Time.deltaTime * 4));
                    }
                }
            }
        }
    }

    public void ChangeSlider()
    {
        _arraySlider++;
        _listGoupe.Clear();

        if (_arraySlider < 3)
        {
            _lightRenderer = _light[_arraySlider].GetComponent<Renderer>();

            for (int i = 0; i < _isPull.Length; i++)
            {
                _isPull[i] = false;
            }

            if (_arraySlider == 1)
            {
                _listGoupe.Add(_slider2);
            }
            else if (_arraySlider == 2)
            {
                _listGoupe.Add(_slider3);
            }
        }  
    }
}
