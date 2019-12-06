using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using XPO;

[RequireComponent(typeof(ARObject))]
public class ParticleObject : MonoBehaviour
{    
    public ParticleSystem particleSystem;

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

    void Start()
    {
        particleSystem.Stop();
    }
  
    private void StartAugmment()
    {
        PlayParticle();
    }

    private void StopAugment()
    {
        StopParticle();
    }

    private void PlayParticle()
    {
        if (!particleSystem.isPlaying)
        {
            particleSystem.Play();
        }

    }

    private void StopParticle()
    {
        if (particleSystem != null)
        {
            if (particleSystem.isPlaying)
            {
                particleSystem.Pause();
            }
        }
    }
}

