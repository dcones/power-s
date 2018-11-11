using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManaBar : MonoBehaviour {

	private PlayerControl player;
	private RectTransform transform;

	// Use this for initialization
	void Start () {
		player = GameObject.FindObjectOfType(typeof(PlayerControl)) as PlayerControl;
		transform = GetComponent<RectTransform>();
		Debug.Log(transform.offsetMax);
	}

	// Update is called once per frame
	void Update () {

		transform.offsetMax = new Vector2(100.0f*player.getMana()/5.0f, transform.offsetMax.y);
	}
}
