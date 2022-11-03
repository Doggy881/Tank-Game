using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Weather : MonoBehaviour
{
    public GameObject rain;
    public GameObject snow;
    public GameObject lightining;

    private void Start()
    {
        rain.SetActive(false);
        snow.SetActive(false);
        lightining.SetActive(false);
    }

    public void ChangeWeather()
    {
        if (GetComponent<TMP_Dropdown>().value == 0)
        {
            rain.SetActive(false);
            snow.SetActive(false);
            lightining.SetActive(false);
        }

        if (GetComponent<TMP_Dropdown>().value == 1)
        {
            rain.SetActive(true);
            snow.SetActive(false);
            lightining.SetActive(false);
        }

        if (GetComponent<TMP_Dropdown>().value == 2)
        {
            rain.SetActive(true);
            snow.SetActive(false);
            lightining.SetActive(true);
        }

        if (GetComponent<TMP_Dropdown>().value == 3)
        {
            rain.SetActive(false);
            snow.SetActive(true);
            lightining.SetActive(false);
        }
    }
}