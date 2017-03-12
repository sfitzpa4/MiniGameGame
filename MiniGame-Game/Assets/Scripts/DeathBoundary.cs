using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathBoundary : MonoBehaviour {

    void OnTriggerEnter(Collider col)
    {
        BallRollerManager.instance.LoseLife();
    }
}
