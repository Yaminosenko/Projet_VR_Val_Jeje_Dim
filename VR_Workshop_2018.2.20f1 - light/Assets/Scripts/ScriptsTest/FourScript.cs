namespace VRTK
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.UI;
    using VRTK.Controllables.ArtificialBased;


    public class FourScript : MonoBehaviour
    {

        //public Image _jauge;
        //public Image _vapeur;
        //public Image _gigaMax;
        //public Canvas _can;
        public VRTK_ArtificialRotator _levier;
        //public VRTK_ArtificialRotator _valve;
        public VRTK_ArtificialSlider _sifflet;
        public Player _player;

        public AudioClip[] _renoSound;

        public bool _finish = false;
        public GameObject _theDoorOfTheEnd;
        public GameObject _aiguilleJauge;
        public GameObject _aiguilleJaugeVapeur;


        private AudioSource _audio;
        private float _startJauge = -150;
        private float _maxJauge = 180;
        private float _maxJaugeGigaMax = 300;
        private float _burnCoal = 0;
        [SerializeField] private float _currentJauge = -150;
        [SerializeField] private float _currentJaugeVapeur;
        [SerializeField] private float _jaugeGigaMax;
        [SerializeField] private float _currentDecrease;
        [SerializeField] private float _initialDeacrease;
        [SerializeField] private float _currentIncrease;


        private int _count = 0;
        //private int _numberOfCoal = 0;
        private bool _isHot = false;
        private bool _vapeurOut = false;
        private bool _renoStart = false;
        private bool _oneTime = false;

        //public event CompleteHeate;


        private void Awake()
        {
            _audio = GetComponent<AudioSource>();
            //_audio.Pause();
            _currentDecrease = _initialDeacrease;
        }

        private void OnTriggerEnter(Collider col)
        {
            if (col.gameObject.tag == "Shovel")
            {
                Shovel _shovel = col.gameObject.GetComponentInParent<Shovel>();
                foreach (GameObject _coal in _shovel._coal)
                {
                    _count++;
                    //_currentJauge += 2.5f;
                    _burnCoal++;
                    //Debug.Log(_count);
                }

                if(col.gameObject.tag == "Player")
                {
                    _count += 5;
                    _burnCoal += 5;
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

            if (_levier.GetValue() >= 25)
            {
                _vapeurOut = true;
            }

            //if (_valve.GetControlInteractableObject().IsGrabbed() == false)
            //{
            //    _valve.SetValue(Mathf.Lerp(_valve.GetValue(), 0, Time.deltaTime * 4));
            //}

            if (_sifflet.GetValue() < -0.70f)
            {
                Debug.Log(_sifflet.GetValue());

                _currentJaugeVapeur -= 6 * Time.deltaTime;
                _currentJauge -= 3 * Time.deltaTime;
                //_player._urDead = true;
                if(_renoStart == false && _currentJaugeVapeur >= -100)
                {
                    //_audio.clip = _renoSound[0];
                    _audio.Play();
                    _audio.UnPause();
                    _renoStart = true;
                }
                

                //if(_audio.)
            }
            else if(_sifflet.GetValue() > -0.60f)
            {

            }
            else
            {
                _audio.Pause();
                _renoStart = false;

            }

            if (_sifflet.GetControlInteractableObject().IsGrabbed() == false)
            {
                _sifflet.SetValue(Mathf.Lerp(_sifflet.GetValue(), -0.4f, Time.deltaTime * 4));
            }

            if(_currentJauge >= 180)
            {
                _finish = true;
                _player._changeRespawn(1);
            }

            if (_currentJaugeVapeur >= 180)
            {
                if (_oneTime == false)
                {
                    _player.DeathIsComing();
                    _currentJauge = 0;
                    _currentJaugeVapeur = 0;
                    _oneTime = true;
                }
            }

            Jauge();
            //UpdateJauge();
            //UpdateJaugeVapeur();
            //UpdateJaugeGigaMax();


            //Quaternion rota = _aiguilleJauge.transform.rotation;
            ////rota.x = _currentJauge;
         
            //Debug.Log(rota);
            _aiguilleJauge.transform.rotation = Quaternion.Euler(_currentJauge, 180, 540);
            _aiguilleJaugeVapeur.transform.rotation = Quaternion.Euler(_currentJaugeVapeur, 180, 540);


        }


        void Jauge()
        {
            if (_currentJauge >= -150 && _currentJauge < -100)
            {
                _currentJauge -= (10) * Time.deltaTime;
            }
            else if (_currentJauge >= -100 && _currentJauge < 10)
            {
                _currentJauge -= (_currentDecrease + 5) * Time.deltaTime;
                _currentJaugeVapeur += _currentDecrease * Time.deltaTime;
                //Debug.Log("ui");
            }
            else if (_currentJauge >= 10 && _currentJauge < 100)
            {
                _currentJaugeVapeur += 15 * Time.deltaTime;
                _currentJauge -= _currentDecrease * Time.deltaTime;
            }
            else if (_currentJauge >= 50)
            {
                _currentJaugeVapeur += 20 * Time.deltaTime;
                _currentJauge -= (_currentDecrease) * Time.deltaTime;
            }


            if (_burnCoal > 0)
            {
                _burnCoal -= 1 * Time.deltaTime*2;
                _currentJauge += _currentIncrease * Time.deltaTime*2;
            }

            if (_currentJaugeVapeur > -100)
            {
                //_currentDecrease = _initialDeacrease / (_currentJaugeVapeur / 30);

            }
            else
            {
                _currentDecrease = _initialDeacrease;
            }

            if (_vapeurOut == true)
            {
                _currentJaugeVapeur -= _maxJauge * Time.deltaTime;
                _currentJauge -= 10 * Time.deltaTime;
                _jaugeGigaMax += _maxJauge * Time.deltaTime;

                if (_currentJaugeVapeur <= 0)
                {
                    _currentJaugeVapeur = 0;
                    _vapeurOut = false;
                }
            }

            //if(_valve.GetValue() > 50)
            //{
            //    _jaugeGigaMax -= _valve.GetValue() / 4 * Time.deltaTime;
            //}


            _currentJauge = Mathf.Clamp(_currentJauge, _startJauge, _maxJauge);
            _currentJaugeVapeur = Mathf.Clamp(_currentJaugeVapeur, _startJauge, _maxJauge);
            _jaugeGigaMax = Mathf.Clamp(_jaugeGigaMax, 0, _maxJaugeGigaMax);
        }

        //void UpdateJauge()
        //{
        //    float ratio = (float)_currentJauge / (float)_maxJauge;

        //    //Debug.Log(ratio);
        //    Mathf.Clamp01(ratio);

        //    Vector3 newScale = _jauge.transform.localScale;
        //    newScale.y = ratio;
        //    _jauge.transform.localScale = newScale;


        //}

        //void UpdateJaugeVapeur()
        //{
        //    float ratio = (float)_currentJaugeVapeur / (float)_maxJauge;

        //    //Debug.Log(ratio);
        //    Mathf.Clamp01(ratio);

        //    Vector3 newScale = _vapeur.transform.localScale;
        //    newScale.y = ratio;
        //    _vapeur.transform.localScale = newScale;
        //}

        //void UpdateJaugeGigaMax()
        //{
        //    float ratio = (float)_jaugeGigaMax / (float)_maxJaugeGigaMax;

        //    //Debug.Log(ratio);
        //    Mathf.Clamp01(ratio);

        //    Vector3 newScale = _gigaMax.transform.localScale;
        //    newScale.y = ratio;
        //    _gigaMax.transform.localScale = newScale;
        //}

    }
}
