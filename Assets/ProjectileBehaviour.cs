using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileBehaviour : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Destroy(gameObject, 2);
	}

	// Collision Logic
	void OnCollisionEnter2D(Collision2D col){
	 Destroy(gameObject);
	}

	// Update is called once per frame
	void Update () {
	}
}
