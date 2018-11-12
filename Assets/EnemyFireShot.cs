using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFireShot : MonoBehaviour {

	int time;
	private GameObject projectile;
	private GameObject projectileClone;
	private SpriteRenderer projectileCloneSprite;
	// Use this for initialization
	void Start () {
		time = 0;
		projectile = GameObject.FindWithTag("EnemyProjectile");
	}

	// Update is called once per frame
	void Update () {
		if (time >= 180) {
			projectileClone = Instantiate(projectile, transform.position + new Vector3(-300.0f, 0.0f, 0.0f), transform.rotation);
			projectileClone.AddComponent<ProjectileBehaviour>();
			projectileClone.GetComponent<SpriteRenderer>().enabled = true;
			projectileClone.GetComponent<Rigidbody2D>().velocity = new Vector2(-800.0f, 0.0f);
			projectileCloneSprite = projectileClone.GetComponent<SpriteRenderer>();
			projectileCloneSprite.flipX = true;
			time = 0;
		}
		time += 1;
	}
}
