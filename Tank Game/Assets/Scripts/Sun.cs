using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sun : MonoBehaviour
{
    public float moveSpeed;

    private float timer = 10;
    private bool goingRight;

    private void Update()
    {
        timer -= Time.deltaTime;

        if (timer <= 0)
        {
            goingRight = !goingRight;
            timer = 10;
        }

        if (goingRight)
        {
            transform.Translate(Vector2.right * moveSpeed * Time.deltaTime);
        }
        else
        {
            transform.Translate(Vector2.left * moveSpeed * Time.deltaTime);
        }
    }
}