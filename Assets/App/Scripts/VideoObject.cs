using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

namespace XPO
{
    [RequireComponent(typeof(ARObject))]
    public class VideoObject : MonoBehaviour
    {
        public GameObject videoTexture;
        public VideoPlayer videoPlayer;

        private ARObject arObject;

        private void Awake()
        {
            arObject = GetComponent<ARObject>();
        }

        private void OnEnable()
        {
            arObject.StartAugmentationCallback += StartAugmment;
            arObject.StopAugmentationCallback += StopAugment;
        }

        private void OnDisable()
        {
            arObject.StartAugmentationCallback -= StartAugmment;
            arObject.StopAugmentationCallback -= StopAugment;
        }

        void Start()
        {
            videoTexture.SetActive(false);
        }

        private void Update()
        {
            if (videoPlayer == null)
            {
                videoPlayer = GetComponentInChildren<VideoPlayer>();
                videoPlayer.Pause();
            }
        }

        private void StartAugmment()
        {
            PlayVideo();
        }

        private void StopAugment()
        {
            StopVideo();
        }

        private void PlayVideo()
        {
            if (!videoPlayer.isPlaying)
            {
                videoTexture.SetActive(true);
                videoPlayer.Play();
            }

        }

        private void StopVideo()
        {
            if (videoPlayer != null)
            {
                if (videoPlayer.isPlaying)
                {
                    videoTexture.SetActive(false);
                    videoPlayer.Pause();
                    //video.time = 0;
                }
            }
        }
    }
}


