using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour {

	private GameObject uiscreen;
	public GameObject player;
	[SerializeField]
	public GameObject gameOverUI;

	public int health;
	// Use this for initialization
	void Start () {
		health = 1;
		player = GameObject.FindWithTag ("Player");
	}
	void Hurt() {
		health--;
		if (health == 0) {
			health = -1;
			gameOverUI.SetActive (true);
			PolygonCollider2D poly = player.GetComponent<PolygonCollider2D> ();
			poly.enabled = false;
				player.GetComponent<Rigidbody2D> ().constraints = RigidbodyConstraints2D.FreezePositionX;
		}

	}
	void OnCollisionEnter2D(Collision2D collision) {
		Patrol enemy = collision.collider.GetComponent<Patrol>();
		if(enemy != null) {
			Hurt();
		}
		if (collision.gameObject.tag == "EnemyProjectile") {
			Hurt();
		}
		if (collision.gameObject.tag == "Abyss") {
			Hurt();
		}
	}
}
