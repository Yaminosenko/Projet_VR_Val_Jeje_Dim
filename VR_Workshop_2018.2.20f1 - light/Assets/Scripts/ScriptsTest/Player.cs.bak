using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour {

    public Image _blackScreen;
    private float _alpha;
    public bool _urDead = false;


    private void Start()
    {
        
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            _urDead = true;
        }

        if(_urDead == true)
        {
            FadeBlack();
        }
    }

    void FadeBlack()
    {
        _blackScreen.color = new Color(0, 0, 0, _alpha);
        _alpha += 5 * Time.deltaTime;
        _alpha = Mathf.Clamp(_alpha, 0, 255);
    }
}
