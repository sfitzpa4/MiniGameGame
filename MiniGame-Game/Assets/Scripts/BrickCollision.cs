using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickCollision : MonoBehaviour {

	public GameObject bricksParticle;
	
	void OnCollisionEnter(Collision other) {
			Instantiate(bricksParticle, transform.position, Quaternion.identity);
			GameManager.instance.DestroyBrick();
			Destroy(gameObject);
	}
}
