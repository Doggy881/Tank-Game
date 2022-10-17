using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Cinemachine;

public class TankMovement : MonoBehaviour
{
    public Transform BarrelRotator;

    private float barrelSpeed;
    private float currentBulletMoveSpeed;
    private float maxBulletMoveSpeed;
    private float bulletMoveSpeedPercentage;
    private float moveSpeed;

    public Transform FirePoint;
    public GameObject Bullet;

    public int PlayerNumber;

    public bool IsItsTurn;
    public static bool canFire;

    public Turning turning;

    public TextMeshProUGUI moveTimerText;
    public TextMeshProUGUI shootingPowerText;
    private float moveTimer;
    private float defaultMoveTimer;
    public static bool moveTimerOn;
    public static bool canMove;

    public static float healthPoints;

    public TextMeshProUGUI winnerText;

    CinemachineTargetGroup targetGroup;

    private void Start()
    {
        barrelSpeed = 20f;
        moveSpeed = 2f;
        canFire = true;
        canMove = true;
        healthPoints = 3f;

        maxBulletMoveSpeed = 10f;

        defaultMoveTimer = 5f;
        moveTimer = defaultMoveTimer;

        targetGroup = GameObject.FindGameObjectWithTag("TargetGroup").GetComponent<CinemachineTargetGroup>();
    }

    private void Update()
    {
        bulletMoveSpeedPercentage = currentBulletMoveSpeed / maxBulletMoveSpeed * 100;

        if (healthPoints <= 0)
        {
            gameObject.SetActive(false);
            winnerText.enabled = true;
            winnerText.text = "Player " + PlayerNumber + " Won!";
        }

        if (IsItsTurn)
        {
            if (PlayerNumber == 1)
            {
                moveTimerText.text = "Fuel : " + Mathf.Round(moveTimer);
                shootingPowerText.text = "ShootingPower : " + Mathf.Round(bulletMoveSpeedPercentage) + "%";

                targetGroup.m_Targets[0].weight = 1f;
                targetGroup.m_Targets[1].weight = 0.2f;

                if (BarrelRotator.rotation.z <= 0.5f || BarrelRotator.rotation.z >= -0.5f)
                {
                    BarrelRotator.Rotate(Vector3.forward, Input.GetAxisRaw("Vertical") * barrelSpeed * Time.deltaTime);
                }

                if (canMove)
                {
                    if (Input.GetAxisRaw("Horizontal") != 0)
                    {
                        moveTimerOn = true;
                    }
                    else
                    {
                        moveTimerOn = false;
                    }
                }

                if (moveTimerOn)
                {
                    transform.Translate(Vector2.right * Input.GetAxisRaw("Horizontal") * moveSpeed * Time.deltaTime);
                    moveTimer -= Time.deltaTime;

                    if (moveTimer <= 0)
                    {
                        canMove = false;
                        moveTimerOn = false;
                    }
                }

                if (Input.GetKey(KeyCode.Space) && canFire)
                {
                    if (currentBulletMoveSpeed < maxBulletMoveSpeed)
                    {
                        currentBulletMoveSpeed += Time.deltaTime * 10;
                    }
                }

                if (Input.GetKeyUp(KeyCode.Space) && canFire)
                {
                    canFire = false;
                    moveTimer = defaultMoveTimer;
                    GameObject BulletObject = Instantiate(Bullet,
                        FirePoint.transform.position, FirePoint.transform.rotation);
                    BulletObject.GetComponent<Rigidbody2D>().AddForce(
                        BarrelRotator.up * currentBulletMoveSpeed, ForceMode2D.Impulse);
                    currentBulletMoveSpeed = 0f;
                }
            }

            if (PlayerNumber == 2)
            {
                moveTimerText.text = "Fuel : " + Mathf.Round(moveTimer);
                shootingPowerText.text = "ShootingPower : " + Mathf.Round(bulletMoveSpeedPercentage) + "%";

                targetGroup.m_Targets[0].weight = 0.2f;
                targetGroup.m_Targets[1].weight = 1f;

                if (BarrelRotator.rotation.z <= 0.5f || BarrelRotator.rotation.z >= -0.5f)
                {
                    BarrelRotator.Rotate(Vector3.forward, Input.GetAxisRaw("Vertical") * barrelSpeed * Time.deltaTime);
                }

                if (canMove)
                {
                    if (Input.GetAxisRaw("Horizontal") != 0)
                    {
                        moveTimerOn = true;
                    }
                    else
                    {
                        moveTimerOn = false;
                    }
                }

                if (moveTimerOn)
                {
                    transform.Translate(Vector2.right * Input.GetAxisRaw("Horizontal") * moveSpeed * Time.deltaTime);
                    moveTimer -= Time.deltaTime;

                    if (moveTimer <= 0)
                    {
                        canMove = false;
                        moveTimerOn = false;
                    }
                }

                if (Input.GetKey(KeyCode.Space) && canFire)
                {
                    if (currentBulletMoveSpeed < maxBulletMoveSpeed)
                    {
                        currentBulletMoveSpeed += Time.deltaTime * 10;
                    }
                }

                if (Input.GetKeyUp(KeyCode.Space) && canFire)
                {
                    canFire = false;
                    moveTimer = defaultMoveTimer;
                    GameObject BulletObject = Instantiate(Bullet,
                        FirePoint.transform.position, FirePoint.transform.rotation);
                    BulletObject.GetComponent<Rigidbody2D>().AddForce(
                        BarrelRotator.up * currentBulletMoveSpeed, ForceMode2D.Impulse);
                    currentBulletMoveSpeed = 0f;
                }
            }
        }
    }
}