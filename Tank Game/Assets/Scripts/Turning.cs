using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Turning : MonoBehaviour
{
    public GameObject Tank1;
    public GameObject Tank2;

    private void Start()
    {
        Tank1.GetComponent<TankMovement>().IsItsTurn = true;
        Tank2.GetComponent<TankMovement>().IsItsTurn = false;
    }

    public void ChangeTurn()
    {
        if (Tank1.GetComponent<TankMovement>().IsItsTurn == true)
        {
            Tank1.GetComponent<TankMovement>().IsItsTurn = false;
            Tank2.GetComponent<TankMovement>().IsItsTurn = true;
            Bullet.CanTurn = true;
        }
        else if (Tank2.GetComponent<TankMovement>().IsItsTurn == true)
        {
            Tank1.GetComponent<TankMovement>().IsItsTurn = true;
            Tank2.GetComponent<TankMovement>().IsItsTurn = false;
            Bullet.CanTurn = true;
        }
    }
}