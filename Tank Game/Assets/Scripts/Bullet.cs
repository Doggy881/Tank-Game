using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class Bullet : MonoBehaviour
{
    private float BulletTimeToLife = 5;
    private ParticleSystem BoomFX;
    private Rigidbody2D rb;

    private Turning turning;

    public static bool CanTurn;

    private bool canParticle;

    CinemachineTargetGroup targetGroup;

    public int damage;

    public AudioClip bulletImpactSFX;
    private AudioSource bulletImpactSFXSource;

    public AudioClip bulletMetalImpactSFX;
    private AudioSource bulletMetalImpactSFXSource;
    public AudioClip metalImpactSFX;
    private AudioSource metalImpactSFXSource;

    private void Start()
    {
        BoomFX = GetComponent<ParticleSystem>();
        rb = GetComponent<Rigidbody2D>();

        turning = GameObject.FindGameObjectWithTag("GameManager").GetComponent<Turning>();

        CanTurn = true;
        canParticle = true;

        targetGroup = GameObject.FindWithTag("TargetGroup").GetComponent<CinemachineTargetGroup>();
        targetGroup.AddMember(gameObject.transform, 1, 1);

        bulletImpactSFXSource = GameObject.FindGameObjectWithTag("ExplosionSFX").GetComponent<AudioSource>();
        bulletMetalImpactSFXSource = GameObject.FindGameObjectWithTag("BulletMetalSFX").GetComponent<AudioSource>();
        metalImpactSFXSource = GameObject.FindGameObjectWithTag("MetalSFX").GetComponent<AudioSource>();
    }

    private void Update()
    {
        BulletTimeToLife -= Time.deltaTime;
        if (BulletTimeToLife <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void FixedUpdate()
    {
        gameObject.transform.right =
             Vector3.Slerp(gameObject.transform.right, rb.velocity.normalized, Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "TileMap")
        {
            gameObject.SetActive(false);
        }

        if (collision.gameObject.tag != "Bullet")
        {
            if (CanTurn)
            {
                turning.ChangeTurn();
                CanTurn = false;
            }
            TankMovement.canFire = true;
            TankMovement.canMove = true;
            TankMovement.moveTimer = TankMovement.defaultMoveTimer;
            TankMovement.moveTimerOn = true;
            GetComponent<SpriteRenderer>().enabled = false;
            rb.freezeRotation = true;
            if (canParticle)
            {
                canParticle = false;
                BoomFX.Play();
                bulletImpactSFXSource.PlayOneShot(bulletImpactSFX);
                if (!BoomFX.isPlaying)
                {
                    targetGroup.RemoveMember(gameObject.transform);
                    Destroy(gameObject);
                }
            }

            if (collision.gameObject.tag == "Player")
            {
                bulletMetalImpactSFXSource.PlayOneShot(bulletImpactSFX);
                metalImpactSFXSource.PlayOneShot(metalImpactSFX);
                TankMovement.healthPoints -= damage;
                Debug.Log("Player " + collision.gameObject.GetComponent<TankMovement>().PlayerNumber + " Got Hit!");
            }
        }
    }
}