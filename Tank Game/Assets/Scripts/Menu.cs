using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
    public GameObject[] UIElementsToeEnable;

    public void Play()
    {
        for (int i = 0; i < UIElementsToeEnable.Length; i++)
        {
            UIElementsToeEnable[i].SetActive(true);
        }

        gameObject.SetActive(false);

        TankMovement.canStart = true;
        TankAnimation.canPlayAudio = true;
    }

    public void Quit()
    {
        Application.Quit();
    }
}