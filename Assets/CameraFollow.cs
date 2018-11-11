using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

	public GameObject player;

	// Use this for initialization
	void Start () {
		player = GameObject.FindWithTag("Player");
	}

	// Update is called once per frame
	void Update () {
		float x = player.transform.position[0];
		float y = this.transform.position[1];
		float z = this.transform.position[2];
		this.transform.position  = new Vector3(x,y,z);
	}
}
