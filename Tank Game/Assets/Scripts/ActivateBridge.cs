using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateBridge : MonoBehaviour
{
    private bool bridgeIsActive;
    public bool canOnlyTurnOn;
    public bool isActivateOnStart;

    public GameObject Bridge;
    private ParticleSystem activateParticle;

    public AudioSource buttonClick;

    private float minPitch = 0.8f;
    private float maxPitch = 1.2f;
    private float minVolume = 0.8f;
    private float maxVolume = 1f;

    private void Start()
    {
        activateParticle = GetComponent<ParticleSystem>();

        if (isActivateOnStart)
        {
            bridgeIsActive = true;
        }
    }

    [System.Obsolete]
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!canOnlyTurnOn)
        {
            bridgeIsActive = !bridgeIsActive;
            Bridge.SetActive(bridgeIsActive);
            ActivateButton();
        }
        else
        {
            if (Bridge.active == true)
            {
                return;
            }
            Bridge.SetActive(true);
            ActivateButton();
        }
    }

    private void ActivateButton()
    {
        activateParticle.Play();
        buttonClick.pitch = Random.Range(minPitch, maxPitch);
        buttonClick.volume = Random.Range(minVolume, maxVolume);
        buttonClick.PlayOneShot(buttonClick.clip);
    }
}