using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;
using VRTK.Controllables.ArtificialBased;

public class HeateObject : MonoBehaviour {

    public VRTK_InteractGrab _leftGrab;
    public VRTK_InteractGrab _rightGrab;
    private VRTK_InteractableObject _challumeau;
    private VRTK_ArtificialRotator _theVanne;
    [SerializeField] private bool _rightGrabTrigger = false;
    [SerializeField] private bool _leftGrabTrigger = false;
    public FrostEffect _freeze;

    public enum Hand { Right, Left };
    public bool _leftHand = false;
    public bool _rightHand = false;

    private void Awake()
    {
        //_theVanne = GetComponent<VRTK_ArtificialRotator>();
        //_theVanne.angleLimits.minimum = -10;
        //_theVanne.angleLimits.maximum = 10;
        _challumeau = GetComponent<VRTK_InteractableObject>();
        _leftGrab.ControllerGrabInteractableObject += IsGrabLeft;
        _leftGrab.ControllerUngrabInteractableObject += isUngrabLeft;
        _rightGrab.ControllerUngrabInteractableObject += isUngrabRight;
        _rightGrab.ControllerGrabInteractableObject += IsGrabRight;
    }

    private void IsGrabLeft(object o, ObjectInteractEventArgs e)
    {
        //_rightGrab.GetGrabbedObject();
        // Debug.Log(_rightGrab.GetGrabbedObject());
        _leftGrabTrigger = true;
    }

    private void IsGrabRight(object o, ObjectInteractEventArgs e)
    {
        // _leftGrab.GetGrabbedObject();
        //Debug.Log(_leftGrab.GetGrabbedObject());
        _rightGrabTrigger = true;
    }

    private void isUngrabLeft(object o, ObjectInteractEventArgs e)
    {
        _leftGrabTrigger = false;
    }

    private void isUngrabRight(object o, ObjectInteractEventArgs e)
    {
        _rightGrabTrigger = false;

    }

    private void Update()
    {
        //if (_rightGrabTrigger == true && _leftGrabTrigger == true)
        //{
        //    //_theVanne.angleLimits.minimum = Mathf.Infinity;
        //    //_theVanne.angleLimits.maximum = Mathf.Infinity;
        //}
        //else
        //{
        //    //_theVanne.angleLimits.minimum = -10;
        //    //_theVanne.angleLimits.maximum = 10;
        //}


        GetGrabByLayer(8, _freeze._nearHeat);
    }

    private void Test()
    {

        switch (_leftHand)
        {
           case false:

                break;
            case true:
                break;
            default:
                Debug.Log("ui");
                break;
        }
    }

    public void GetGrabByLayer(int _layer, bool condition)
    {
        if (_rightGrab.GetGrabbedObject() != null)
        {

            if (_rightGrab.GetGrabbedObject().layer == _layer)
            {
                _rightHand = true;
                _freeze._nearHeat = true;
            }
            else
            {
                _rightHand = false;
            }
        }
        else
        {
            _rightHand = false;
        }

        if (_leftGrab.GetGrabbedObject() != null)
        {
            if (_leftGrab.GetGrabbedObject().layer == _layer)
            {
                _leftHand = true;
                _freeze._nearHeat = true;
            }
            else
            {
                _leftHand = false;
            }
        }
        else
        {
            _leftHand = false;
        }

        if (_rightHand == false && _leftHand == false)
        {
            _freeze._nearHeat = false;
        }
    }

}
