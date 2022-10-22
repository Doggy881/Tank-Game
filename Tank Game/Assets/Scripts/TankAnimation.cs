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

    public static bool canPlayAudio;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetAxisRaw("Horizontal") != 0 && GetComponent<TankMovement>().IsItsTurn
            && TankMovement.canMove && GetComponent<TankMovement>().PlayerNumber == 1 && TankMovement.moveTimer > 0)
        {
            PlayDrivingSound();
            animator.SetBool("IsDriving", true);
        }
        else if (Input.GetAxisRaw("Horizontal") == 0 || TankMovement.moveTimer <= 0)
        {
            PlayIdleSound();
            animator.SetBool("IsDriving", false); 
        }

        if (Input.GetAxisRaw("Horizontal") != 0 && GetComponent<TankMovement>().IsItsTurn
            && TankMovement.canMove && GetComponent<TankMovement>().PlayerNumber == 2 && TankMovement.moveTimer > 0)
        {
            PlayDrivingSound();
            animator.SetBool("IsDriving", true);
        }
        else if (Input.GetAxisRaw("Horizontal") == 0 || TankMovement.moveTimer <= 0)
        {
            PlayIdleSound();
            animator.SetBool("IsDriving", false);
        }
    }

    private void PlayDrivingSound()
    {
        if (canPlayAudio)
        {
            idleEngineSFXSource.Stop();
            idleEngineSFXSource2.Stop();
            if (!engineRunningSFXSource.isPlaying)
            {
                engineRunningSFXSource.PlayOneShot(engineRunningSFX);
            }
        }
    }

    private void PlayIdleSound()
    {
        if (canPlayAudio)
        {
            engineRunningSFXSource.Stop();
            idleEngineSFXSource2.Stop();
            if (!idleEngineSFXSource.isPlaying)
            {
                //Debug.Log("Playing Player1 Idle SFX");
                idleEngineSFXSource.PlayOneShot(idleEngineSFXSource.clip);
            }
        }
    }

    private void PlayIdleSound2()
    {
        if (canPlayAudio)
        {
            engineRunningSFXSource.Stop();
            idleEngineSFXSource.Stop();
            if (!idleEngineSFXSource2.isPlaying)
            {
                //Debug.Log("Playing Player2 Idle SFX");
                idleEngineSFXSource2.PlayOneShot(idleEngineSFXSource2.clip);
            }
        }
    }
}