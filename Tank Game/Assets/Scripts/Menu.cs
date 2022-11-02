using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class Menu : MonoBehaviour
{
    public GameObject music;

    public CinemachineTargetGroup targetGroup;

    private void Start()
    {
        for (int i = 0; i < targetGroup.m_Targets.Length; i++)
        {
            targetGroup.m_Targets[i].weight = 1f;
        }

        TankMovement.canStart = false;
        TankAnimation.canPlayAudio = false;
    }

    public void Play()
    {
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