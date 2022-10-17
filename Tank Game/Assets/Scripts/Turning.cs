using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Turning : MonoBehaviour
{
    public GameObject Tank1;
    public GameObject Tank2;

    public TextMeshProUGUI turnText;

    private void Start()
    {
        Tank1.GetComponent<TankMovement>().IsItsTurn = true;
        Tank2.GetComponent<TankMovement>().IsItsTurn = false;

        turnText.text = "It's Player 1's Turn!";
    }

    public void ChangeTurn()
    {
        if (Tank1.GetComponent<TankMovement>().IsItsTurn == true)
        {
            Tank1.GetComponent<TankMovement>().IsItsTurn = false;
            Tank2.GetComponent<TankMovement>().IsItsTurn = true;
            turnText.text = "It's Player 2's Turn!";
            Bullet.CanTurn = true;
        }
        else if (Tank2.GetComponent<TankMovement>().IsItsTurn == true)
        {
            Tank1.GetComponent<TankMovement>().IsItsTurn = true;
            Tank2.GetComponent<TankMovement>().IsItsTurn = false;
            turnText.text = "It's Player 1's Turn!";
            Bullet.CanTurn = true;
        }
    }
}