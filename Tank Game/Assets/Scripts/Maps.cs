using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Maps : MonoBehaviour
{
    public GameObject[] maps;

    private void Start()
    {
        for (int i = 0; i < maps.Length; i++)
        {
            maps[i].SetActive(false);
        }

        int randomMap = Random.Range(0, maps.Length);
        maps[randomMap].SetActive(true);
    }
}