using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;
using VRTK.GrabAttachMechanics;

public class GrabDistance : MonoBehaviour {


    private Transform transformControllerLeft;
    private Transform transformControllerRight;
    private VRTK_ControllerEvents controllerEventsLeft;
    private VRTK_ControllerEvents controllerEventsRight;

    public GameObject _rightHand;
    public GameObject _leftHand;


    private void Start()
    {
        StartCoroutine(GetControllerEvent());
    }

    private void Update()
    {

        
        
        if(controllerEventsLeft != null && controllerEventsRight != null)
        {
            if (controllerEventsLeft.triggerPressed == true)
            {
                Debug.Log("left");
                RayCastTrigger(transformControllerLeft);
            }

            if (controllerEventsRight.triggerPressed == true)
            {
                Debug.Log("right");

                RayCastTrigger(transformControllerRight);
            }
        }
        

        //Debug.Log(controllerEventsLeft.triggerClicked);
        //Debug.Log(controllerEventsLeft.triggerClicked);


    }

    void RayCastTrigger(Transform controller)
    {
        RaycastHit hit;
        // Does the ray intersect any objects excluding the player layer
        if (Physics.Raycast(controller.position, controller.TransformDirection(Vector3.forward), out hit, Mathf.Infinity))
        {
            if (hit.transform.gameObject.GetComponent<VRTK_InteractableObject>() != null)
            {
                var _grab = hit.transform.gameObject.GetComponent<VRTK_ChildOfControllerGrabAttach>();

                
            }


            Debug.DrawRay(controller.position, controller.TransformDirection(Vector3.forward) * hit.distance, Color.yellow, Mathf.Infinity);
           
        }
        else
        {
            Debug.DrawRay(controller.position, controller.TransformDirection(Vector3.forward) * 1000, Color.white, Mathf.Infinity);
            Debug.Log("Did not Hit");
        }
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
