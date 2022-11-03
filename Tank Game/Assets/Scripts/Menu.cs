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

    private void Start()
    {
        for (int i = 0; i < targetGroup.m_Targets.Length; i++)
        {
            targetGroup.m_Targets[i].weight = 1f;
        }

        TankMovement.canStart = false;
        TankAnimation.canPlayAudio = false;
        pauseMenu.SetActive(false);
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

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.P))
        {
            Debug.Log("Pressed Escape Or P!");
            if (isPaused)
            {
                Debug.Log("Resuming!");
                Resume();
            }
            else
            {
                Debug.Log("Paused!");
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
        Debug.Log("Paused!");
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