using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.UI;

public class NightMode : MonoBehaviour
{
    private bool nightMode;

    public Light2D globalLight;
    public Light2D[] tileMapGlobalLights;
    public GameObject desertSun;
    public GameObject[] headLights;

    private void Start()
    {
        globalLight.intensity = 0.8f;
        foreach (var light in tileMapGlobalLights)
        {
            light.intensity = 0.8f;
        }
        for (int i = 0; i < headLights.Length; i++)
        {
            headLights[i].SetActive(nightMode);
        }
        gameObject.GetComponent<Toggle>().isOn = nightMode;
    }

    public void ToggleNightMode()
    {
        nightMode = !nightMode;

        if (nightMode)
        {
            globalLight.intensity = 0.2f;
            foreach (var light in tileMapGlobalLights)
            {
                light.intensity = 0.2f;
            }
            for (int i = 0; i < headLights.Length; i++)
            {
                headLights[i].SetActive(nightMode);
            }
            gameObject.GetComponent<Toggle>().isOn = nightMode;
            desertSun.SetActive(!nightMode);
        }
        else if (!nightMode)
        {
            globalLight.intensity = 0.8f;
            foreach (var light in tileMapGlobalLights)
            {
                light.intensity = 0.8f;
            }
            for (int i = 0; i < headLights.Length; i++)
            {
                headLights[i].SetActive(nightMode);
            }
            gameObject.GetComponent<Toggle>().isOn = nightMode;
            desertSun.SetActive(!nightMode);
        }
    }
}