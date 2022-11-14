using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mine : MonoBehaviour
{
    private ParticleSystem explosionParticle;
    public AudioSource explosionSFX;

    private void Start()
    {
        explosionParticle = GetComponent<ParticleSystem>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if (collision.GetComponent<TankMovement>().PlayerNumber == 1)
            {
                TankMovement.healthPoints -= 1;
                explosionParticle.Play();
                explosionSFX.PlayOneShot(explosionSFX.clip);
                GetComponent<SpriteRenderer>().enabled = false;
            }
            else if(collision.GetComponent<TankMovement>().PlayerNumber == 2)
            {
                TankMovement.healthPoints2 -= 1;
                explosionParticle.Play();
                explosionSFX.PlayOneShot(explosionSFX.clip);
                GetComponent<SpriteRenderer>().enabled = false;
            }
        }

        if (collision.tag == "Bullet")
        {
            explosionParticle.Play();
            explosionSFX.PlayOneShot(explosionSFX.clip);
            GetComponent<SpriteRenderer>().enabled = false;
        }
    }
}