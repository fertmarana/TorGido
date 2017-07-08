﻿   using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	private Rigidbody2D Rigid;
	private Animator anim;
	private bool facingRight = true;
	public float MoveSpeed;
	float defense;

	// Use this for initialization
	void Start () {
		Rigid = gameObject.GetComponent<Rigidbody2D>();
		anim = gameObject.GetComponent<Animator> ();

		defense = 0.0f;

		gameObject.GetComponent<HPManager> ().HP = 10; //setando 10 de hp para o gido
	}
	
	// Update is called once per frame
	void Update () {
		Move ();
	}

	void Move() {
		float h = Input.GetAxis ("Horizontal");
		float v = Input.GetAxis ("Vertical");

		if (h != 0.0f || v != 0.0f) {
			if (h > 0.0f && !facingRight) {
				facingRight = true;
				transform.localScale = new Vector3 (transform.localScale.x * (-1), transform.localScale.y, transform.localScale.z);
			} else if (h < 0.0f && facingRight) {
				facingRight = false;
				transform.localScale = new Vector3 (transform.localScale.x * (-1), transform.localScale.y, transform.localScale.z);
			}
			anim.SetBool ("isWalking", true);
		} else 
			anim.SetBool ("isWalking", false);

		Vector2 movement= new Vector2 (h, v);

		Rigid.velocity = movement.normalized * MoveSpeed;
	}

	public void CalculateDamage(float damage){
		float final = damage - defense;

		if (final < 0)
			final = 0;

		gameObject.GetComponent<HPManager> ().decreaseHP (final);
	}


}
