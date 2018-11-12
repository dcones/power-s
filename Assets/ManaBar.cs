using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManaBar : MonoBehaviour {

	private PlayerControl player;
	private RectTransform rectTransform;

	// Use this for initialization
	void Start () {
		player = GameObject.FindObjectOfType(typeof(PlayerControl)) as PlayerControl;
		rectTransform = GetComponent<RectTransform>();
	}

	// Update is called once per frame
	void Update () {

		rectTransform.offsetMax = new Vector2(203f*player.getMana()/5.0f, rectTransform.offsetMax.y);
	}
}
