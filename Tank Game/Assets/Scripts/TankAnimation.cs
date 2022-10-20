using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankAnimation : MonoBehaviour
{
    private Animator animator;

    public AudioSource idleEngineSFXSource;
    public AudioSource idleEngineSFXSource2;

    public AudioClip engineRunningSFX;
    public AudioSource engineRunningSFXSource;

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
        idleEngineSFXSource.Stop();
        if (!engineRunningSFXSource.isPlaying)
        {
            engineRunningSFXSource.PlayOneShot(engineRunningSFX);
        }
    }

    private void PlayDrivingSound()
    {
        engineRunningSFXSource.Stop();
        if (!idleEngineSFXSource.isPlaying)
        {
            if (Random.Range(0, 1) == 0)
            {
                idleEngineSFXSource.PlayOneShot(idleEngineSFXSource.clip);
            }
            else
            {
                idleEngineSFXSource2.PlayOneShot(idleEngineSFXSource.clip);
            }
        }
    }
}