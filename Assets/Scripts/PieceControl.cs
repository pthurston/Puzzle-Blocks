using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PieceControl : MonoBehaviour {

	PieceQueue creator;
	List<CollisionCheck> childColliders;

	// Use this for initialization
	void Awake() {
		creator = GameObject.FindWithTag("Piece Queue").GetComponent<PieceQueue>();
		rigidbody2D.isKinematic = true;

		childColliders = new List<CollisionCheck>();

		InvokeRepeating("UpdateHeight", 0.75f, 1.0f);

		for(int i = 0; i < transform.childCount; i++){
			GameObject child = transform.GetChild(i).gameObject;
			childColliders.Add((CollisionCheck)	child.AddComponent("CollisionCheck"));
		}
	}

	void UpdateHeight(){
		if(!Move(0, -1)){
			creator.CanCreate = true;
			Destroy(this);
		}
	}
	
	// Update is called once per frame
	void Update () {
		int h = 0;
		if(Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown("d"))
			h = 1;
		else if(Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown("a"))
			h = -1;

		//if(transform.position.y <= -4)
		//	Destroy(this);

		if(h != 0)
			Move(h, 0);

		if(Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown("s")){
			if(!Move(0, -1)){
				creator.CanCreate = true;
				Destroy(this);
			}
		}

		if(Input.GetKeyDown("r") || Input.GetKeyDown("w") || Input.GetKeyDown(KeyCode.UpArrow))
			Rotate(90);

	}

	bool CheckCollidersForCollision(int x, int y){
		for(int i = 0; i < childColliders.Count; i++){
			if(childColliders[i].CheckDirectionForCollision(x, y)){
				return true;
			}
		}
		return false;
	}

	bool CheckCollidersForCollision(float theta){
		for(int i = 0; i < childColliders.Count; i++){
			if(childColliders[i].CheckRotationForCollision(theta)){
				return true;
			}
		}
		return false;
	}

	bool Move(int x, int y){
		if(CheckCollidersForCollision(x, y))
			return false;
		transform.position += new Vector3(x, y, 0);
		return true;
	}

	bool Rotate(float theta){
		if(CheckCollidersForCollision(theta))
			return false;
		transform.Rotate(Vector3.forward * theta);
		return true;


	}
}
