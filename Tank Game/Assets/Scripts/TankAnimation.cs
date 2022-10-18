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

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        Debug.Log("Horizontal Input : " + Input.GetAxisRaw("Horizontal"));
        Debug.Log("Is Tanks Turn : " + GetComponent<TankMovement>().IsItsTurn);
        Debug.Log("Can Tank Move : " + TankMovement.canMove);

        if (Input.GetAxisRaw("Horizontal") != 0 && GetComponent<TankMovement>().IsItsTurn && TankMovement.canMove)
        {
            idleEngineSFXSource.Stop();
            if (!engineRunningSFXSource.isPlaying)
            {
                engineRunningSFXSource.Play();
            }
            animator.SetBool("IsDriving", true);

            Debug.Log("Driving...");
        }
        else
        {
            engineRunningSFXSource.Stop();
            if (!idleEngineSFXSource.isPlaying)
            {
                idleEngineSFXSource.PlayOneShot(idleEngineSFX);
            }
            animator.SetBool("IsDriving", false);

            Debug.Log("Idling...");
        }
    }
}