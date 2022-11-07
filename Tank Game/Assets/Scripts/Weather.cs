using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Weather : MonoBehaviour
{
    public GameObject rain;
    public GameObject snow;
    public GameObject lightining;

    private TMP_Dropdown weatherDropdown;

    private void Start()
    {
        rain.SetActive(false);
        snow.SetActive(false);
        lightining.SetActive(false);

        weatherDropdown = GetComponent<TMP_Dropdown>();
    }

    public void ChangeWeather()
    {
        //Nothing
        if (weatherDropdown.value == 0)
        {
            rain.SetActive(false);
            snow.SetActive(false);
            lightining.SetActive(false);
        }

        //Rain
        if (weatherDropdown.value == 1)
        {
            rain.SetActive(true);
            snow.SetActive(false);
            lightining.SetActive(false);
        }

        //Storm
        if (weatherDropdown.value == 2)
        {
            rain.SetActive(true);
            snow.SetActive(false);
            lightining.SetActive(true);
        }

        //Snow
        if (weatherDropdown.value == 3)
        {
            rain.SetActive(false);
            snow.SetActive(true);
            lightining.SetActive(false);
        }
    }
}