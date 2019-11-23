namespace VRTK
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class DeathTeleportDestination : VRTK_DestinationMarker
    {

        //public Transform destination;
        private bool lastUsePressedState = false;
        public VRTK_ControllerEvents EventsController;

        //private void OnTriggerStay(Collider collider)
        //{
        //    VRTK_ControllerEvents controller = (collider.GetComponent<VRTK_ControllerEvents>() ? collider.GetComponent<VRTK_ControllerEvents>() : collider.GetComponentInParent<VRTK_ControllerEvents>());
        //    if (controller != null)
        //    {
        //        if (lastUsePressedState == true && !controller.triggerPressed)
        //        {
        //            float distance = Vector3.Distance(transform.position, destination.position);
        //            VRTK_ControllerReference controllerReference = VRTK_ControllerReference.GetControllerReference(controller.gameObject);
        //            OnDestinationMarkerSet(SetDestinationMarkerEvent(distance, destination, new RaycastHit(), destination.position, controllerReference));
        //        }
        //        lastUsePressedState = controller.triggerPressed;
        //    }
        //}


        public void TeleportBrooo(Transform destination)
        {
            VRTK_ControllerEvents controller = EventsController;
            {
                Debug.Log("1");
                //if (lastUsePressedState == true && !controller.triggerPressed)
                //{
                    Debug.Log("2");
                    float distance = Vector3.Distance(transform.position, destination.position);
                    VRTK_ControllerReference controllerReference = VRTK_ControllerReference.GetControllerReference(controller.gameObject);
                    OnDestinationMarkerSet(SetDestinationMarkerEvent(distance, destination, new RaycastHit(), destination.position, controllerReference));
                //}
                lastUsePressedState = controller.triggerPressed;
            }
        }
    }
}
