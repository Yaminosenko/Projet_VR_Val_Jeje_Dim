using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK.Controllables.ArtificialBased;

public class JoystickDrone : MonoBehaviour {

    private VRTK_ArtificialRotator _levier;
    public Rigidbody _rb;
    public float _speed = 5;
    public float _rotateSpeed = 2;
    public bool _isLeft = true;

    private void OnEnable()
    {
        _levier = gameObject.GetComponent<VRTK_ArtificialRotator>();
    }

    private void Update()
    {


        if(_levier.GetControlInteractableObject().IsGrabbed() == false)
        {
            _levier.SetValue(Mathf.Lerp(_levier.GetValue(),0,Time.deltaTime*4));
        }



        //JoystickGauche
        if (_isLeft == true)
        {
            //Vector3 _var = transform.forward * _levier.GetValue();
            //_var.y = _rb.velocity.y;
            //_rb.velocity = _var;

            Vector3 _frontVel = Vector3.zero;

            if (_levier.GetValue() > 10 || _levier.GetValue() < -10)
            {
                _frontVel = transform.forward * _levier.GetValue();
            }
            else
            {
                _frontVel = Vector3.zero;
            }

            _rb.transform.position = Vector3.MoveTowards(_rb.transform.position, _rb.transform.position + _frontVel, _speed * Time.deltaTime);
        }
        else
        {
            if (_levier.GetValue() >= 10)
            {
                _rb.transform.Rotate(0, _rotateSpeed, 0);
            }
            if (_levier.GetValue() <= -10 )
            {
                _rb.transform.Rotate(0, -_rotateSpeed, 0);
            }
        }
    }
}
