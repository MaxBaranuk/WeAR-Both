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
    public class FutureLabEventHandler : MonoBehaviour,
                                                ITrackableEventHandler
    {
        [SerializeField] private GameObject AIM;
        [SerializeField] private GameObject FutureLab;
        [SerializeField] private GameObject FutureLabPanel;

        [SerializeField] private GameObject[] TargetAndCanvas;

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
            AIM.SetActive(false);
            FutureLab.SetActive(true);

            foreach (var go in TargetAndCanvas)
            {
                if (go.activeSelf) go.SetActive(false);
            }            
        }

        private void OnTrackingLost()
        {
            AIM.SetActive(true);
            FutureLab.SetActive(false);
        }

        #endregion // PRIVATE_METHODS
    }
}
