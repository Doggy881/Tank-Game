using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mute : MonoBehaviour
{
    public AudioSource music;
    public Animator backgroundAnimation;

    private bool demoMode;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            demoMode = !demoMode;
            music.mute = demoMode;
        }

        if (demoMode)
        {
            backgroundAnimation.SetBool("StartWar", demoMode);
        }
    }
}