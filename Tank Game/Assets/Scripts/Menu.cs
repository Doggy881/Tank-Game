using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class Menu : MonoBehaviour
{
    public GameObject music;

    public CinemachineTargetGroup targetGroup;

    private bool isPaused;
    public GameObject pauseMenu;
    public GameObject mapSelect;

    public Transform[] tanks;
    private Vector2 tank1Location;
    private Vector2 tank2Location;

    private void Start()
    {
        for (int i = 0; i < targetGroup.m_Targets.Length; i++)
        {
            targetGroup.m_Targets[i].weight = 1f;
        }

        TankMovement.canStart = false;
        TankAnimation.canPlayAudio = false;
        pauseMenu.SetActive(false);

        tank1Location = tanks[0].position;
        tank2Location = tanks[1].position;
    }

    public void Play()
    {
        mapSelect.SetActive(false);

        TankMovement.canStart = true;
        TankAnimation.canPlayAudio = true;
        music.GetComponent<AudioLowPassFilter>().enabled = false;
        music.GetComponent<AudioHighPassFilter>().enabled = false;
        Time.timeScale = 1f;
        tanks[0].position = tank1Location;
        tanks[1].position = tank2Location;
        foreach (var tank in tanks)
        {
            tank.rotation = Quaternion.identity;
        }
    }

    public void Quit()
    {
        Application.Quit();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.P))
        {
            if (isPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Pause()
    {
        music.GetComponent<AudioLowPassFilter>().enabled = true;
        music.GetComponent<AudioHighPassFilter>().enabled = true;
        isPaused = true;
        Time.timeScale = 0;
        pauseMenu.SetActive(true);
    }

    public void Resume()
    {
        music.GetComponent<AudioLowPassFilter>().enabled = false;
        music.GetComponent<AudioHighPassFilter>().enabled = false;
        isPaused = false;
        Time.timeScale = 1;
        pauseMenu.SetActive(false);
    }
}