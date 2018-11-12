using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

	public GameObject player;
	public Rigidbody2D body;
	public float offset;

	// Use this for initialization
	void Start () {
		player = GameObject.FindWithTag("Player");
		body = gameObject.GetComponent<Rigidbody2D>() as Rigidbody2D;
		this.transform.position = new Vector3(player.transform.position[0], this.transform.position[1], this.transform.position[2]);
		offset = this.transform.position[0] - player.transform.position[0];

	}

	// Update is called once per frame
	void Update () {
		float x = player.transform.position[0] - this.transform.position[0] - offset;
		body.velocity = new Vector2(4*x, 0.0f);
	}
}
