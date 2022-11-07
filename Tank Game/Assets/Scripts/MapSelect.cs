using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MapSelect : MonoBehaviour
{
    public Weather weather;
    public GameObject mapSelect;

    private TMP_Dropdown weatherDropdown;

    public GameObject[] maps;
    public GameObject map;
    public GameObject snowMap;

    private void Start()
    {
        weatherDropdown = weather.GetComponent<TMP_Dropdown>();
    }

    public void SelectMap()
    {
        ResetMaps();
        mapSelect.SetActive(false);
        if (weatherDropdown.value == 3)
        {
            snowMap.SetActive(true);
        }
        else
        {
            map.SetActive(true);
        }
    }

    private void ResetMaps()
    {
        foreach (var map in maps)
        {
            map.SetActive(false);
        }
    }
}