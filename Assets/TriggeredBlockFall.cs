using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggeredBlockFall : MonoBehaviour {


		public GameObject player;
		float time;
		int direction;
		// Use this for initialization
		void Start () {
			time = 0.0f;
			direction = 0;
			player = GameObject.FindWithTag("Player");
		}

		// Update is called once per frame
		void Update () {
			if (direction == 0 && Mathf.Abs(transform.position[0] - player.transform.position[0]) < 200) {
				direction = -12;
				time = 0.0f;
			}
			else if (time >= 15 && direction < 0){
				direction = 1;
				time = 0.0f;
			}
			else if (time >= 180 && direction > 0){
				direction = 0;
			}
			time += 1.0f;
			transform.position = new Vector3(transform.position[0], transform.position[1] + direction, transform.position[2]);
		}
	}
