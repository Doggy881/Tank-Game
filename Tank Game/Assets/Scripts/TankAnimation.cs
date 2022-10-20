using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankAnimation : MonoBehaviour
{
    private Animator animator;

    public AudioClip idleEngineSFX;
    public AudioSource idleEngineSFXSource;

    public AudioClip engineRunningSFX;
    public AudioSource engineRunningSFXSource;

    public static bool canPlayAudio;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetAxisRaw("Horizontal") != 0 && GetComponent<TankMovement>().IsItsTurn
            && TankMovement.canMove && GetComponent<TankMovement>().PlayerNumber == 1)
        {
            PlayIdleSound();
            animator.SetBool("IsDriving", true);
        }
        else if(Input.GetAxisRaw("Horizontal") == 0)
        {
            PlayDrivingSound();
            animator.SetBool("IsDriving", false);
        }

        if (Input.GetAxisRaw("Horizontal") != 0 && GetComponent<TankMovement>().IsItsTurn
            && TankMovement.canMove && GetComponent<TankMovement>().PlayerNumber == 2)
        {
            PlayIdleSound();
            animator.SetBool("IsDriving", true);
        }
        else if (Input.GetAxisRaw("Horizontal") == 0)
        {
            PlayDrivingSound();
            animator.SetBool("IsDriving", false);
        }
    }

    private void PlayIdleSound()
    {
        if (canPlayAudio)
        {
            idleEngineSFXSource.Stop();
            if (!engineRunningSFXSource.isPlaying)
            {
                engineRunningSFXSource.PlayOneShot(engineRunningSFX);
            }
        }
    }

    private void PlayDrivingSound()
    {
        if (canPlayAudio)
        {
            engineRunningSFXSource.Stop();
            if (!idleEngineSFXSource.isPlaying)
            {
                idleEngineSFXSource.PlayOneShot(idleEngineSFX);
            }
        }
    }
}