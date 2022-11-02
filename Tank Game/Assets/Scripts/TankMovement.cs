using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Cinemachine;
using UnityEngine.UI;

public class TankMovement : MonoBehaviour
{
    private float barrelSpeed;
    private float currentBulletMoveSpeed;
    private float maxBulletMoveSpeed;
    private float bulletMoveSpeedPercentage;
    private float moveSpeed;
    public Slider bulletMoveSpeedSlider;
    private bool isGoingDown;

    public Transform FirePoint;
    public GameObject Bullet;
    public Transform BarrelRotator;

    public int PlayerNumber;

    public bool IsItsTurn;
    public static bool canFire;

    public Turning turning;

    public static float moveTimer;
    public static float defaultMoveTimer;
    public static bool moveTimerOn;
    public static bool canMove;
    public static bool canStart;

    public static float healthPoints;
    public static float healthPoints2;
    public Slider healthSlider;
    public TextMeshProUGUI winnerText;
    public GameObject winnerMenu;

    public static bool hasWon;

    public AudioSource shootingSFXSource;
    public AudioClip shootingSFX;

    CinemachineTargetGroup targetGroup;

    public GameObject mainMenu;

    public Camera cam;

    private Rigidbody2D rb;
    public ParticleSystem fuelParticles;

    private void Start()
    {
        barrelSpeed = 50f;
        moveSpeed = 3.5f;
        canFire = true;
        canMove = true;
        healthPoints = 3f;
        healthPoints2 = 3f;

        maxBulletMoveSpeed = 10f;

        defaultMoveTimer = 5f;
        moveTimer = defaultMoveTimer;

        targetGroup = GameObject.FindGameObjectWithTag("TargetGroup").GetComponent<CinemachineTargetGroup>();

        mainMenu.SetActive(true);

        rb = GetComponent<Rigidbody2D>();
    }

    [System.Obsolete]
    private void Update()
    {
        bulletMoveSpeedPercentage = currentBulletMoveSpeed / maxBulletMoveSpeed * 100;

        if (IsItsTurn && canStart)
        {
            if (PlayerNumber == 1)
            {
                healthSlider.value = healthPoints.Remap(0, 3, 0, 1);
                bulletMoveSpeedSlider.value = bulletMoveSpeedPercentage / 100;

                if (healthPoints <= 0)
                {
                    gameObject.SetActive(false);
                    fuelParticles.gameObject.SetActive(false);
                    winnerMenu.SetActive(true);
                    winnerText.text = "Player 2 Won!";
                    hasWon = true;
                }

                targetGroup.m_Targets[0].weight = 1f;
                targetGroup.m_Targets[1].weight = 0.2f;

                if (BarrelRotator.rotation.eulerAngles.z > 270 || BarrelRotator.rotation.eulerAngles.z < 90)
                {
                    BarrelRotator.Rotate(Vector3.forward, Input.GetAxisRaw("Vertical") * barrelSpeed * Time.deltaTime);
                }

                else if (BarrelRotator.rotation.eulerAngles.z > 90 && BarrelRotator.rotation.eulerAngles.z < 95)
                {
                    BarrelRotator.Rotate(Vector3.forward, -1 * barrelSpeed * Time.deltaTime);
                }

                else if (BarrelRotator.rotation.eulerAngles.z < 270 && BarrelRotator.rotation.eulerAngles.z > 265)
                {
                    BarrelRotator.Rotate(Vector3.forward, 1 * barrelSpeed * Time.deltaTime);
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
                    if (currentBulletMoveSpeed < maxBulletMoveSpeed && !isGoingDown)
                    {
                        currentBulletMoveSpeed += Time.deltaTime * 10;
                    }
                    else if (currentBulletMoveSpeed >= maxBulletMoveSpeed && !isGoingDown)
                    {
                        isGoingDown = true;
                    }
                    else if (isGoingDown)
                    {
                        currentBulletMoveSpeed -= Time.deltaTime * 10;
                        if (currentBulletMoveSpeed <= 0)
                        {
                            isGoingDown = false;
                        }
                    }
                }

                if (Input.GetKeyUp(KeyCode.Space) && canFire)
                {
                    shootingSFXSource.PlayOneShot(shootingSFX);
                    canFire = false;
                    GameObject BulletObject = Instantiate(Bullet,
                        FirePoint.transform.position, BarrelRotator.transform.rotation);
                    BulletObject.GetComponent<Rigidbody2D>().AddForce(
                        BarrelRotator.up * currentBulletMoveSpeed, ForceMode2D.Impulse);
                    currentBulletMoveSpeed = 0f;
                }

                bulletMoveSpeedSlider.value = bulletMoveSpeedPercentage / 100;

                if (Input.GetAxisRaw("Horizontal") == 0)
                {
                    rb.constraints = RigidbodyConstraints2D.FreezePosition;
                }
                else
                {
                    rb.constraints = RigidbodyConstraints2D.None;
                }

                fuelParticles.emissionRate = moveTimer * 2f;
            }

            if (PlayerNumber == 2)
            {
                healthSlider.value = healthPoints2.Remap(0, 3, 0, 1);
                bulletMoveSpeedSlider.value = bulletMoveSpeedPercentage / 100;

                if (healthPoints2 <= 0)
                {
                    gameObject.SetActive(false);
                    fuelParticles.gameObject.SetActive(false);
                    winnerMenu.SetActive(true);
                    winnerText.text = "Player 1 Won!";
                    hasWon = true;
                }

                targetGroup.m_Targets[0].weight = 0.2f;
                targetGroup.m_Targets[1].weight = 1f;

                if (BarrelRotator.rotation.eulerAngles.z > 270 || BarrelRotator.rotation.eulerAngles.z < 90)
                {
                    BarrelRotator.Rotate(Vector3.forward, Input.GetAxisRaw("Vertical") * barrelSpeed * Time.deltaTime);
                }

                else if (BarrelRotator.rotation.eulerAngles.z > 90 && BarrelRotator.rotation.eulerAngles.z < 95)
                {
                    BarrelRotator.Rotate(Vector3.forward, -1 * barrelSpeed * Time.deltaTime);
                }

                else if (BarrelRotator.rotation.eulerAngles.z < 270 && BarrelRotator.rotation.eulerAngles.z > 265)
                {
                    BarrelRotator.Rotate(Vector3.forward, 1 * barrelSpeed * Time.deltaTime);
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
                    if (currentBulletMoveSpeed < maxBulletMoveSpeed && !isGoingDown)
                    {
                        currentBulletMoveSpeed += Time.deltaTime * 10;
                    }
                    else if (currentBulletMoveSpeed >= maxBulletMoveSpeed && !isGoingDown)
                    {
                        isGoingDown = true;
                    }
                    else if (isGoingDown)
                    {
                        currentBulletMoveSpeed -= Time.deltaTime * 10;
                        if (currentBulletMoveSpeed <= 0)
                        {
                            isGoingDown = false;
                        }
                    }
                }

                if (Input.GetKeyUp(KeyCode.Space) && canFire)
                {
                    shootingSFXSource.PlayOneShot(shootingSFX);
                    canFire = false;
                    GameObject BulletObject = Instantiate(Bullet,
                        FirePoint.transform.position, FirePoint.transform.rotation);
                    BulletObject.GetComponent<Rigidbody2D>().AddForce(
                        BarrelRotator.up * currentBulletMoveSpeed, ForceMode2D.Impulse);
                    currentBulletMoveSpeed = 0f;
                }

                if (Input.GetAxisRaw("Horizontal") == 0)
                {
                    rb.constraints = RigidbodyConstraints2D.FreezePosition;
                }
                else
                {
                    rb.constraints = RigidbodyConstraints2D.None;
                }

                fuelParticles.emissionRate = moveTimer * 2f;
            }
        }
    }
}