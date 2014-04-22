using UnityEngine;
using System.Collections;

public class ChangeSceneTrigger : MonoBehaviour {

	public string nextScene;
	public string tag;

	void Start(){
		Vector2 rotate = Vector2.up;
		rotate = rotate.Rotate2D(90);
		Debug.Log("Vector Test: "  + rotate);
		if(collider)
			collider.isTrigger = true;
		
		if(collider2D)
			collider2D.isTrigger = true;
	}

	void ChangeScene(){
		Application.LoadLevel(nextScene);
	}

	void OnTriggerEnter(Collider other){
		if(other.tag == tag)
			ChangeScene();
	}

	void OnTriggerEnter2D(Collider2D other){
		Debug.Log("Collision with :" + other.tag);
		if(other.tag == tag)
			ChangeScene();
	}
}
