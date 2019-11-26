
    using System.Collections;
    using System.Collections.Generic;
using System.Linq;
using UnityEngine;
    using UnityEngine.UI;
    using VRTK;
    using VRTK.Controllables.ArtificialBased;

    public class Player : MonoBehaviour
    {

        public Image _blackScreen;
        private float _alpha;
        public bool _urDead = false;
        private VRTK_HeadsetFade _fade;
        private VRTK_BasicTeleport _tp;
        public Transform _tpDestination;
        private DeathTeleportDestination _teleportDeath;
        public GameObject _playerBody;
        public GameObject _cameraRig;
        private Transform _actualCameraTransform;
        private SliderFrostArea _sliderManager;
        public bool _isInFrostArea;
        public Rigidbody[] _arrayRd;
        public VRTK_InteractableObject[] _arrayInteactable;

        public Transform[] _respawn;
         

       //public event Event startFade; 


        private void Awake()
        {
            _fade = GetComponent<VRTK_HeadsetFade>();
            _teleportDeath = GetComponent<DeathTeleportDestination>();
        _sliderManager = GetComponent<SliderFrostArea>();
       


        _fade.HeadsetFadeStart += _fade_HeadsetFadeStart;
            _fade.HeadsetFadeComplete += _fade_HeadsetFadeComplete;
            _fade.HeadsetUnfadeStart += _fade_HeadsetUnfadeStart;
            _fade.HeadsetUnfadeComplete += _fade_HeadsetUnfadeComplete;
        }

        private void OnDisable()
        {
            _fade.HeadsetFadeStart -= _fade_HeadsetFadeStart;
            _fade.HeadsetFadeComplete -= _fade_HeadsetFadeComplete;
            _fade.HeadsetUnfadeStart -= _fade_HeadsetUnfadeStart;
            _fade.HeadsetUnfadeComplete -= _fade_HeadsetUnfadeComplete;
        }

        private void _fade_HeadsetUnfadeComplete(object sender, HeadsetFadeEventArgs e)
        {
            
        }

        private void _fade_HeadsetUnfadeStart(object sender, HeadsetFadeEventArgs e)
        {
           //Debug.Log("3");
        }

        private void _fade_HeadsetFadeComplete(object sender, HeadsetFadeEventArgs e)
        {
           // Debug.Log("2");
            //_tp.Teleport(_tpDestination,_tpDestination.position, _tpDestination.rotation,true);
            
            _actualCameraTransform = _cameraRig.transform;
            GameObject _deadBody = Instantiate(_playerBody, _actualCameraTransform.position, _actualCameraTransform.rotation);
            if (_isInFrostArea == true)
            {
                _arrayRd = _deadBody.GetComponentsInChildren<Rigidbody>();
                _arrayInteactable = _deadBody.GetComponentsInChildren<VRTK_InteractableObject>();
                foreach (Rigidbody item in _arrayRd)
                {
                    item.isKinematic = true;
                }
                foreach (VRTK_InteractableObject inter in _arrayInteactable)
                {
                    inter.isGrabbable = false;
                }
            }
            _teleportDeath.TeleportBrooo(_tpDestination);
            _fade.Unfade(1f);
        }

        private void _fade_HeadsetFadeStart(object sender, HeadsetFadeEventArgs e)
        {
            //Debug.Log("1");
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.P))
            {
                _urDead = true;
            }

            if (_urDead == true)
            {
                _fade.Fade(Color.black, 1f);

                _urDead = false;
            }
        }

        void FadeBlack()
        {
            //_blackScreen.color = new Color(0, 0, 0, _alpha);
            //_alpha += 5 * Time.deltaTime;
            //_alpha = Mathf.Clamp(_alpha, 0, 255);
        }

        public void _changeRespawn(int _nbRespawn)
        {
            _tpDestination = _respawn[_nbRespawn];
        }

        public void DeathIsComing()
        {
             _urDead = true;
        
            if (_sliderManager._isPull[0] == true && _sliderManager._isPull[1] == true)
            {
                _sliderManager.ChangeSlider();
            }
        }
    }


