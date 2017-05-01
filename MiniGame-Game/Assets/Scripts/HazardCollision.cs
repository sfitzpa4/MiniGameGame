using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HazardCollision : MonoBehaviour
{

    void OnTriggerEnter(Collider col)
    {
        BallRollerManager.instance.LoseLife();
    }
}