using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Background : MonoBehaviour
{
    private Animator animator;

    private float timer = 1f;

    public AudioSource[] explosionSFX;

    public float pitchMin;
    public float pitchMax;
    public float volumeMin;
    public float volumeMax;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        timer -= Time.deltaTime;

        if (timer <= 0)
        {
            if (Random.Range(0, 5) == 0)
            {
                animator.SetBool("StartWar", true);
            }
            timer = 1f;
        }
    }

    public void StopWar()
    {
        animator.SetBool("StartWar", false);
    }

    public void Explosion()
    {
        int randomNum = Random.Range(0, explosionSFX.Length);

        explosionSFX[randomNum].volume = Random.Range(volumeMin, volumeMax);
        explosionSFX[randomNum].pitch = Random.Range(pitchMin, pitchMax);
        explosionSFX[randomNum].PlayOneShot(explosionSFX[randomNum].clip);
    }
}