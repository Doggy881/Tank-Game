using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankAnimation : MonoBehaviour
{
    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetAxisRaw("Horizontal") != 0 && GetComponent<TankMovement>().IsItsTurn)
        {
            animator.SetBool("IsDriving", true);
        }
        else
        {
            animator.SetBool("IsDriving", false);
        }

        if (Input.GetAxisRaw("Horizontal") != 0 && GetComponent<TankMovement>().IsItsTurn)
        {
            animator.SetBool("IsDriving", true);
        }
        else
        {
            animator.SetBool("IsDriving", false);
        }
    }
}