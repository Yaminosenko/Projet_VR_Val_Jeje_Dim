
namespace VRTK
{

    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using VRTK;
    using VRTK.Controllables.ArtificialBased;

    public class Vanne : MonoBehaviour {

        public VRTK_InteractGrab _leftGrab;
        public VRTK_InteractGrab _rightGrab;
        private VRTK_ArtificialRotator _theVanne;
        [SerializeField] private bool _rightGrabTrigger = false;
        [SerializeField] private bool _leftGrabTrigger = false;

        private void Awake()
        {
            _theVanne = GetComponent<VRTK_ArtificialRotator>();
            _theVanne.angleLimits.minimum = -10;
            _theVanne.angleLimits.maximum = 10;
            _leftGrab.ControllerGrabInteractableObject += IsGrabLeft;
            _leftGrab.ControllerUngrabInteractableObject += isUngrabLeft;
            _rightGrab.ControllerUngrabInteractableObject += isUngrabRight;
            _rightGrab.ControllerGrabInteractableObject += IsGrabRight;
        }

        private void IsGrabLeft(object o, ObjectInteractEventArgs e)
        {
            _leftGrabTrigger = true; 
        }

        private void IsGrabRight(object o, ObjectInteractEventArgs e)
        {
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
            if (_rightGrabTrigger == true && _leftGrabTrigger == true)
            {
                _theVanne.angleLimits.minimum = Mathf.Infinity;
                _theVanne.angleLimits.maximum = Mathf.Infinity;
            }
            else
            {
                //_theVanne.angleLimits.minimum = -10;
                //_theVanne.angleLimits.maximum = 10;
            }
        }
    }
}
