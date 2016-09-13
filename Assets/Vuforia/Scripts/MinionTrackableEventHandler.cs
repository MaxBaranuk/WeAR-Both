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
    public class MinionTrackableEventHandler : MonoBehaviour,
                                                ITrackableEventHandler
    {
        public GameObject houseScene;
        public GameObject doorsScene;
        public GameObject floorScene; 
        public GameObject minionScene;
        public GameObject minion;
        public GameObject shadow;                                                                                               
        public GameObject target;
        //        public GameObject indicator;
        public bool isSite;
        public GameObject platform;
        MinionStateChanger stateChanger;
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

            stateChanger = minion.GetComponent<MinionStateChanger>();
        }

        void Update() {
            if (Input.GetKeyDown(KeyCode.Escape)) Application.Quit();
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
            stateChanger.isSite = isSite;
            target.SetActive(false);
            floorScene.SetActive(false);
            houseScene.SetActive(false);
            doorsScene.SetActive(false);
            minionScene.SetActive(true);
            //minion.SetActive(true);
            //shadow.SetActive(true);
//            if (isSite) stateChanger.isSite = true;
            
            floorCanvas.SetActive(false);
            houseCanvas.SetActive(false);
            doorscanvas.SetActive(false);
            minionCanvas.SetActive(true);
            Screen.orientation = ScreenOrientation.Portrait;
            SceneStateManager.instance.targetFind = true;
            SceneStateManager.instance.curentManager.SetActive(true);
            //           indicator.SetActive(true);
        }


        private void OnTrackingLost()
        {
            //minion.SetActive(false);
            //shadow.SetActive(false);
            
            //platform.SetActive(false);
            if (SceneStateManager.instance!=null&&!SceneStateManager.instance.isSelfieMode)
            {

                target.SetActive(true);
                
                SceneStateManager.instance.curentManager.SetActive(false);
                SceneStateManager.instance.targetFind = false;
                minionScene.SetActive(false);
                minionCanvas.SetActive(false);
            }
            //            indicator.SetActive(false);
            //            houseScene.SetActive (false);
            //            houseCanvas.SetActive(false);
            //            Screen.orientation = ScreenOrientation.AutoRotation;
        }

        #endregion // PRIVATE_METHODS
    }
}
