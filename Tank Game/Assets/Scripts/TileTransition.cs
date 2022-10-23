using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileTransition : MonoBehaviour
{
    private bool devMode;

    private void Start()
    {
        if (!devMode)
        {
            for (int i = 0; i < transform.childCount; i++)
            {
                transform.GetChild(i).gameObject.GetComponent<SpriteRenderer>().enabled = false;
            }
        }
    }
}