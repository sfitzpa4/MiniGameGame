using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableCollision : MonoBehaviour {

    // Use this for initialization
    void OnCollisionEnter(Collision other)
    {
        Destroy(gameObject);
    }

}
