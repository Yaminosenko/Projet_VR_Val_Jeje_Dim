using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerCloseDoor : MonoBehaviour {

    public AnimOnStart[] _anim;
    public bool test = false;


    private void OnTriggerEnter(Collider col)
    {
       if(col.gameObject.tag == "Player")
        {
            for (int i = 0; i < _anim.Length; i++)
            {
                _anim[i]._rewind = true;
            }
           
            //Destroy(this.gameObject);
        } 
    }

    private void Update()
    {
        if(test == true)
        {
            for (int i = 0; i < _anim.Length; i++)
            {
                _anim[i]._rewind = true;

            }
            
        }
    }
}
