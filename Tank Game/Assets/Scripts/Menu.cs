using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
    public GameObject[] UIElementsToeEnable;
    public GameObject music;

    public void Play()
    {
        for (int i = 0; i < UIElementsToeEnable.Length; i++)
        {
            UIElementsToeEnable[i].SetActive(true);
        }

        gameObject.SetActive(false);

        TankMovement.canStart = true;
        TankAnimation.canPlayAudio = true;
        music.GetComponent<AudioLowPassFilter>().enabled = false;
        music.GetComponent<AudioHighPassFilter>().enabled = false;
    }

    public void Quit()
    {
        Application.Quit();
    }
}