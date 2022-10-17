using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

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
    public int damageRange;

    private void Start()
    {
        BoomFX = GetComponent<ParticleSystem>();
        rb = GetComponent<Rigidbody2D>();

        turning = GameObject.FindGameObjectWithTag("GameManager").GetComponent<Turning>();

        CanTurn = true;

        targetGroup = GameObject.FindWithTag("TargetGroup").GetComponent<CinemachineTargetGroup>();
        targetGroup.AddMember(gameObject.transform, 1, 1);

        canParticle = true;
    }

    private void Update()
    {
        RaycastHit2D hit = Physics2D.CircleCast(transform.position, damageRange, Vector2.zero, damageRange);

        if (hit.collider)
        {
            Debug.Log("Do Damage!");
        }

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
        if (collision.gameObject.tag != "Bullet")
        {
            if (CanTurn)
            {
                turning.ChangeTurn();
                CanTurn = false;
            }
            TankMovement.canFire = true;
            TankMovement.canMove = true;
            TankMovement.moveTimerOn = true;
            GetComponent<SpriteRenderer>().enabled = false;
            rb.freezeRotation = true;
            if (canParticle)
            {
                canParticle = false;
                BoomFX.Play();
                if (!BoomFX.isPlaying)
                {
                    targetGroup.RemoveMember(gameObject.transform);
                    Destroy(gameObject);
                }
            }

            if (collision.gameObject.tag == "Player")
            {
                TankMovement.healthPoints--;
            }
        }
    }
}