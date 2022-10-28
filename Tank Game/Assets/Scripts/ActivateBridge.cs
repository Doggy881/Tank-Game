using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateBridge : MonoBehaviour
{
    private bool bridgeIsActive;
    public bool canOnlyTurnOn;

    public GameObject Bridge;
    private ParticleSystem activateParticle;

    private void Start()
    {
        activateParticle = GetComponent<ParticleSystem>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!canOnlyTurnOn)
        {
            bridgeIsActive = !bridgeIsActive;
            Bridge.SetActive(bridgeIsActive);
            ActivateParticle();
        }
        else
        {
            Bridge.SetActive(true);
            ActivateParticle();
        }
    }

    private void ActivateParticle()
    {
        activateParticle.Play();
    }
}