using UnityEngine;
using System.Collections;

public class Tween2D : MonoBehaviour {

	Vector2 oldPos;
	Vector2 targetPos;
	float startTime;
	float travelTime;

	void Awake(){
		oldPos = transform.position;
		targetPos = transform.position;
		travelTime = 0.0f;
		startTime = 0.0f;
	}

	void Update(){
		if(travelTime == 0.0f)
			return;
		float t = (Time.time - startTime) / travelTime;
		if(t > 1.0f)
			return;
		transform.position = Vector2.Lerp(oldPos, targetPos, t);
	}

	public void MoveTo(Vector2 newPos, float time){
		oldPos = transform.position; 
		targetPos = newPos;
		startTime = Time.time;
		travelTime = time;
	}

	public void MoveByOffset(Vector2 offset, float time){
		MoveTo((Vector2)transform.position + offset, time);
	}
}

