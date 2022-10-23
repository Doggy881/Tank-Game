using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class Menu : MonoBehaviour
{
    public GameObject[] UIElementsToeEnable;
    public GameObject music;

    public CinemachineTargetGroup targetGroup;

    private void Start()
    {
        for (int i = 0; i < targetGroup.m_Targets.Length; i++)
        {
            targetGroup.m_Targets[i].weight = 1f;
        }
    }

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