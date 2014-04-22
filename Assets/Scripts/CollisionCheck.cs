using UnityEngine;
using System.Collections;

public class CollisionCheck : MonoBehaviour {

	public bool CheckDirectionForCollision(int dx, int dy){
		Vector2 checkPos = transform.position;
		checkPos.x += dx;
		checkPos.y += dy;

		return CheckLineCastToPoint(checkPos);
	}

	public bool CheckRotationForCollision(float theta){
		Vector2 checkPos = transform.position;

		checkPos = checkPos.RotateAround2D(transform.parent.position, theta);
		Debug.DrawLine(transform.position, checkPos);
		return CheckLineCastToPoint(checkPos);
	}

	bool CheckLineCastToPoint(Vector2 point){
		RaycastHit2D[] hits;
		hits = Physics2D.LinecastAll(transform.position, point);

		if(hits == null)
			return false;
		Debug.Log(hits.Length);
		for(int i = 0; i < hits.Length; i++){
			Debug.DrawRay(transform.position, (Vector3)hits[i].point - transform.position);
			if(hits[i].transform != transform && hits[i].transform != transform.parent){
				Debug.Log(gameObject.name + ", " + hits[i].transform.name + " True");
				return true;
			}
		}

		return false;
	}
}
