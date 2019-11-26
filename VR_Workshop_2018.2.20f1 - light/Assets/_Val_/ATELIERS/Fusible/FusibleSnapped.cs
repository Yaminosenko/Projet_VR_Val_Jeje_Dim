namespace vrtk
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using VRTK;

    public class FusibleSnapped : MonoBehaviour
    {
        public VRTK.VRTK_SnapDropZone snapCode;
        public bool snapped = false;
        public FusibleBoardManager FBM;
        

        // Use this for initialization
        void Start()
        {
            snapCode.ObjectSnappedToDropZone += isSnaped;
        }

        void Update()
        {
            if (snapCode.GetCurrentSnappedInteractableObject() != null)
                snapped = true;
            else
                snapped = false;
        }

        void isSnaped(object sender, SnapDropZoneEventArgs e)
        {
            snapped = true;
            FBM.snappedOnes++;
        }
    }
}



