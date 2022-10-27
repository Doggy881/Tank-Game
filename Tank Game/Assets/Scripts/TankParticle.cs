using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankParticle : MonoBehaviour
{
    public Transform tank;

    private void Update()
    {
        transform.position = tank.position;
    }
}