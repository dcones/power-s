using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour {

	public int health;
	// Use this for initialization
	void Start () {
		health = 1;
	}
	void Hurt() {
		health--;
		if(health <= 0)
			Debug.Log("GAME OVER");
			//SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}
	void OnCollisionEnter2D(Collision2D collision) {
		Patrol enemy = collision.collider.GetComponent<Patrol>();
		if(enemy != null) {
			Hurt();
		}
	}
}
