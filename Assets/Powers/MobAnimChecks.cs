using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobAnimChecks : MonoBehaviour {
	public Animator animator;
	public MobDeath pc;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		animator.SetBool ("Death", pc.getHealth() <= 0);
	}
}
