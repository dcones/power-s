using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

	public GameObject player;
	public Rigidbody2D body;
	public Vector3 offset;

	// Use this for initialization
	void Start () {
		player = GameObject.FindWithTag("Player");
		body = gameObject.GetComponent<Rigidbody2D>() as Rigidbody2D;
		this.transform.position = new Vector3(player.transform.position[0], this.transform.position[1], this.transform.position[2]);
		//offset = new Vector3(this.transform.position[0] - player.transform.position[0], this.transform.position[1] - player.transform.position[1], this.transform.position[2] - player.transform.position[2]);
		offset = new Vector3(0.0f, 100.0f, 0);

	}

	// Update is called once per frame
	void Update () {
		Vector3 new_velocity = player.transform.position - this.transform.position + offset;
		body.velocity = new_velocity*4.0f;
	}
}
