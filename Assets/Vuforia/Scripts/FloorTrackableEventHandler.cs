/*==============================================================================
Copyright (c) 2010-2014 Qualcomm Connected Experiences, Inc.
All Rights Reserved.
Confidential and Proprietary - Protected under copyright and other laws.
==============================================================================*/

using UnityEngine;

namespace Vuforia
{
    /// <summary>
    /// A custom handler that implements the ITrackableEventHandler interface.
    /// </summary>
    public class FloorTrackableEventHandler : MonoBehaviour,
                                                ITrackableEventHandler
    {
        public GameObject houseScene;
        public GameObject doorsScene;
        public GameObject floorScene;
        public GameObject minionScene;

        public GameObject target;
 //       public GameObject indicator;

        public GameObject houseCanvas;
        public GameObject doorscanvas;
        public GameObject floorCanvas;
        public GameObject minionCanvas;
        #region PRIVATE_MEMBER_VARIABLES

        private TrackableBehaviour mTrackableBehaviour;
    
        #endregion // PRIVATE_MEMBER_VARIABLES



        #region UNTIY_MONOBEHAVIOUR_METHODS
    
        void Start()
        {
            mTrackableBehaviour = GetComponent<TrackableBehaviour>();
            if (mTrackableBehaviour)
            {
                mTrackableBehaviour.RegisterTrackableEventHandler(this);
            }
        }

        #endregion // UNTIY_MONOBEHAVIOUR_METHODS



        #region PUBLIC_METHODS

        /// <summary>
        /// Implementation of the ITrackableEventHandler function called when the
        /// tracking state changes.
        /// </summary>
        public void OnTrackableStateChanged(
                                        TrackableBehaviour.Status previousStatus,
                                        TrackableBehaviour.Status newStatus)
        {
            if (newStatus == TrackableBehaviour.Status.DETECTED ||
                newStatus == TrackableBehaviour.Status.TRACKED ||
                newStatus == TrackableBehaviour.Status.EXTENDED_TRACKED)
            {
                OnTrackingFound();
            }
            else
            {
                OnTrackingLost();
            }
        }

        #endregion // PUBLIC_METHODS



        #region PRIVATE_METHODS


        private void OnTrackingFound()
        {

            target.SetActive(false);

            floorScene.SetActive(true);
            houseScene.SetActive(false);
            doorsScene.SetActive(false);
            minionScene.SetActive(false);

            floorCanvas.SetActive(true);
            houseCanvas.SetActive(false);
            doorscanvas.SetActive(false);
            minionCanvas.SetActive(false);
            Screen.orientation = ScreenOrientation.Landscape;
//            indicator.SetActive(true);
        }


        private void OnTrackingLost()
        {
            target.SetActive(true);
            //            indicator.SetActive(false);
            //            houseScene.SetActive (false);
            //            houseCanvas.SetActive(false);
            //            Screen.orientation = ScreenOrientation.AutoRotation;
        }

        #endregion // PRIVATE_METHODS
    }
}
