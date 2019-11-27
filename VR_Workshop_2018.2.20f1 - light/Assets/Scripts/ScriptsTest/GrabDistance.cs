using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class GrabDistance : MonoBehaviour {


    private Transform transformControllerLeft;
    private Transform transformControllerRight;
    private VRTK_ControllerEvents controllerEventsLeft;
    private VRTK_ControllerEvents controllerEventsRight;


    private void Start()
    {
        StartCoroutine(GetControllerEvent());
    }

    private void Update()
    {

        float _rightTrigger = Input.GetAxis("Oculus_CrossPlatform_PrimaryHandTrigger");

        if (controllerEventsLeft.triggerPressed == true && controllerEventsLeft != null)
        {
            RaycastHit hit;
            // Does the ray intersect any objects excluding the player layer
            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity, layerMask))
            {
                Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
                Debug.Log("Did Hit");
            }
            else
            {
                Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 1000, Color.white);
                Debug.Log("Did not Hit");
            }
        }


        Debug.Log(controllerEventsLeft.triggerClicked);
        Debug.Log(controllerEventsLeft.triggerClicked);
        

    }

    IEnumerator GetControllerEvent()
    {

        yield return new WaitForSeconds(0.1f);
        transformControllerLeft = VRTK_DeviceFinder.DeviceTransform(VRTK_DeviceFinder.Devices.LeftController); // ne peut être appeler qu'une frame après le start
        transformControllerRight = VRTK_DeviceFinder.DeviceTransform(VRTK_DeviceFinder.Devices.RightController);
        controllerEventsLeft = transformControllerLeft.GetComponent<VRTK_ControllerEvents>();
        controllerEventsRight = transformControllerRight.GetComponent<VRTK_ControllerEvents>();

    }
}
