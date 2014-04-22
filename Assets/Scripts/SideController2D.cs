using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SideController2D : MonoBehaviour {

	public float maxSpeed;

	PieceQueue pieceQueue;

	Animator animator;

	bool facingRight = true;

	Stack<Vector2> savedPositions;

	// Use this for initialization
	void Start () {
		pieceQueue = GameObject.FindWithTag("Piece Queue").GetComponent<PieceQueue>();
		savedPositions = new Stack<Vector2>();
		animator = GetComponent<Animator>();
	}
	

	void Update(){
		if(Input.GetKeyDown("v")){
			Debug.Log("saved pos");
			savedPositions.Push((Vector2)transform.position);
		}
		if(Input.GetKeyDown("u")){
			Debug.Log("loaded pos");
			transform.position = (Vector3)savedPositions.Pop();
		}
	}
	// Update is called once per frame
	void FixedUpdate () {

		float h = pieceQueue.CanCreate ? Input.GetAxis("Horizontal") : 0.0f;
		if(h > 0 && !facingRight)
			facingRight = true;
		else if(h < 0 && facingRight)
			facingRight = false;

		float facingDirection = facingRight ? 1 : -1;
		transform.localScale = new Vector3(facingDirection, transform.localScale.y, transform.localScale.z);

		float v = rigidbody2D.velocity.y;

		bool grounded = false;
		if(Physics2D.OverlapCircle(transform.position, 0.2f, ~(1 << 8))){
			grounded = true;
			Debug.DrawRay(transform.position, Vector3.up * -0.2f);
			Debug.DrawRay(transform.position, Vector3.right * 0.2f);
		}

		Debug.Log(grounded);

		rigidbody2D.velocity = new Vector2(h * maxSpeed,v);	

		if(Input.GetKeyDown("space") && grounded){
			Debug.Log("Jump");
			rigidbody2D.AddForce(new Vector2(0, 300));
		}

		if(animator){
			if(h != 0)
				animator.SetBool("IsMoving", true);
			else
				animator.SetBool("IsMoving", false);

			animator.SetBool("Grounded", grounded);
		}
		
	}
}
