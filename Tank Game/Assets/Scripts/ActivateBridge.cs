using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateBridge : MonoBehaviour
{
    private bool bridgeIsActive;

    public GameObject Bridge;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        bridgeIsActive = !bridgeIsActive;
        Bridge.SetActive(bridgeIsActive);
    }
}