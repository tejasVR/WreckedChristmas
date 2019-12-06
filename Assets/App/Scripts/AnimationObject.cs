using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace XPO
{
    [RequireComponent(typeof(ARObject))]
    public class AnimationObject : MonoBehaviour
    {
        public Animator[] animators;

        public bool stopOnLost;

        private ARObject arObject;

        private void Awake()
        {
            arObject = GetComponent<ARObject>();
        }

        private void OnEnable()
        {
            arObject.TrackingFoundCallback += StartAugmment;
            arObject.TrackingLostCallback += StopAugment;
        }

        private void OnDisable()
        {
            arObject.TrackingFoundCallback -= StartAugmment;
            arObject.TrackingLostCallback -= StopAugment;
        }

        private void StartAugmment()
        {
            PlayAnimation();
        }

        private void StopAugment()
        {
            if (stopOnLost)
            {
                StopAnimation();
            }
        }

        private void PlayAnimation()
        {
            for (int i = 0; i < animators.Length; i++)
            {
                animators[i].ResetTrigger("stop");
                animators[i].SetTrigger("play");
            }
        }

        private void StopAnimation()
        {
            for (int i = 0; i < animators.Length; i++)
            {
                animators[i].SetTrigger("stop");
            }
        }
    }
}


