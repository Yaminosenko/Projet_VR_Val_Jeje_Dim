using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorControl : MonoBehaviour {

	public Animation anim;
	public Animation anim2;
	public string animName;
	public string animName2;
	public string objTag;

	public void OnTriggerEnter (Collider col)
	{
		if (col.tag == "Player")
		{
            
			anim[animName].speed = -1;
			anim[animName].time = anim[animName].length;
			anim.Play(animName);
			Invoke("DestroyMe", anim[animName].length);

            if(anim2 != null)
            {
                anim2[animName2].speed = -1;
                anim2[animName2].time = anim2[animName2].length;
                anim2.Play(animName2);
                Invoke("DestroyMe", anim2[animName2].length);
            }
		}
	}

	public void DestroyMe ()
	{
		Destroy(gameObject, 0.1f);
	}
}
