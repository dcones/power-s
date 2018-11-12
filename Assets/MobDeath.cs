using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobDeath : MonoBehaviour {

	private float health;
	private bool dead;
	private Vector3 deathLocation;
	private PolygonCollider2D poly;
	private Rigidbody2D body;
	// Use this for initialization
	void Start () {
		dead = false;
		health = 5.0f;
		poly = gameObject.GetComponent<PolygonCollider2D>();
		body = gameObject.GetComponent<Rigidbody2D>();
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
		if (health <= 0 && !dead) {
			Destroy(gameObject, 1);
			dead = true;
			deathLocation = body.position;
			Destroy(body);
			poly.enabled = false;
		}
		if (dead) {
			transform.position = deathLocation;
		}
	}
	public float getHealth () {
		return health;
	}
}
