using UnityEngine;
using System.Collections;

public class Tween2D : MonoBehaviour {

	Vector2 oldPos;
	Vector2 targetPos;
	float startTime;
	float travelTime;

	float zPos;

	bool isMoving = false;

	void Awake(){
		oldPos = transform.position;
		targetPos = transform.position;
		travelTime = 0.0f;
		startTime = 0.0f;
		zPos = transform.position.z;
	}

	void Update(){
		if(travelTime == 0.0f)
			return;
		float t = (Time.time - startTime) / travelTime;
		if(t > 1.0f){
			if(isMoving)
				gameObject.SendMessage("OnArrival", SendMessageOptions.DontRequireReceiver);
			isMoving = false;
			return;
		}
		Vector2 newPos = Vector2.Lerp(oldPos, targetPos, t);
		transform.position = new Vector3(newPos.x, newPos.y, zPos);
	}

	public void MoveTo(Vector2 newPos, float time){
		isMoving = true;
		oldPos = transform.position; 
		targetPos = newPos;
		startTime = Time.time;
		travelTime = time;
	}

	public void MoveByOffset(Vector2 offset, float time){
		MoveTo((Vector2)transform.position + offset, time);
	}
}

