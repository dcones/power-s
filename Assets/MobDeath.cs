using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobDeath : MonoBehaviour {

	private float health;
	// Use this for initialization
	void Start () {
		health = 5.0f;
	}

	// Collision Logic
	void OnCollisionEnter2D(Collision2D col){

	 // Only vertical collisions resets the jump counter
	 if (col.gameObject.tag == "Projectile") {
		 health -= 1.0f;
	 }
	}

	// Update is called once per frame
	void Update () {
		if (health <= 0) {
			Destroy(gameObject);
		}
	}
}
