using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTransitions : MonoBehaviour {
		private Rigidbody2D rb;
	public Animator animator;
	void Start () {
		rb = gameObject.GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
		animator.SetFloat("Speed", Mathf.Abs(rb.velocity.x));
		animator.SetBool ("isJumpUp", rb.velocity.y > 0);
		animator.SetBool ("isJumpDown", rb.velocity.y < 0);
	}
}
