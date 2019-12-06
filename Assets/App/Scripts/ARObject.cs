using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Vuforia;

namespace XPO
{
    public class ARObject : MonoBehaviour, ITrackableEventHandler
    {
        #region EVENTS

        public event Action TrackingFoundCallback;
        public event Action TrackingLostCallback;

        public event Action StartAugmentationCallback;
        public event Action StopAugmentationCallback;

        protected void OnTrackingFound()
        {
            if (TrackingFoundCallback != null)
            {
                TrackingFoundCallback?.Invoke();
            }
        }

        protected void OnTrackingLost()
        {
            if (TrackingLostCallback != null)
            {
                TrackingLostCallback?.Invoke();
            }
        }

        protected void OnStartAugmentation()
        {
            if (StartAugmentationCallback != null)
            {
                StartAugmentationCallback?.Invoke();
            }
        }

        protected void OnStopAugmentation()
        {
            if (StopAugmentationCallback != null)
            {
                StopAugmentationCallback?.Invoke();
            }
        }

        #endregion

        public UnityEvent TrackingFoundEvent;
        public UnityEvent TrackingLostEvent;

        private TrackableBehaviour mTrackableBehaviour;

        public void Start()
        {
            mTrackableBehaviour = GetComponent<TrackableBehaviour>();

            if (mTrackableBehaviour)
            {
                mTrackableBehaviour.RegisterTrackableEventHandler(this);
            }
        }

        public void OnTrackableStateChanged(TrackableBehaviour.Status previousStatus, TrackableBehaviour.Status newStatus)
        {
            if (newStatus == TrackableBehaviour.Status.DETECTED ||
                newStatus == TrackableBehaviour.Status.TRACKED ||
                newStatus == TrackableBehaviour.Status.EXTENDED_TRACKED)
            {
                TrackingFound();
            }

            if (newStatus == TrackableBehaviour.Status.NO_POSE ||
                newStatus == TrackableBehaviour.Status.LIMITED)
            {
                TrackingLost();
            }
        }

        public virtual void TrackingFound()
        {
            OnTrackingFound();
            Debug.Log("ARObject " + gameObject.name + " found");
            TrackingFoundEvent.Invoke();
        }

        public void StartAugemntation()
        {
            OnStartAugmentation();
        }

        public void StopAugmnetation()
        {
            OnStopAugmentation();
        }

        public virtual void TrackingLost()
        {
            OnTrackingLost();
            TrackingLostEvent.Invoke();
            StopAugmnetation();
            

            Debug.Log("ARObject " + gameObject.name + " lost");

        }
    }
}


