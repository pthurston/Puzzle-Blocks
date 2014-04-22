using UnityEngine;
using System.Collections;

public class ObjectMover : MonoBehaviour {

	public enum Direction{
		Up,
		Down,
		Left,
		Right
	};

	public Direction direction;
	public float speed = 5.0f;
	public float speedVariation = 1.0f;

	public float distance = 20.0f;

	Vector2 dir;
	float actualSpeed;
	Vector2 startPos;

	void Awake(){
		switch(direction){
			case Direction.Up:
				dir = Vector2.up;
				break;
			case Direction.Down:
				dir = -Vector2.up;
				break;
			case Direction.Left:
				dir = -Vector2.right;
				break;
			case Direction.Right:
				dir = Vector2.right;
				break;
		}

		startPos = transform.position;
		actualSpeed = speed + Random.Range(-speedVariation, speedVariation);
	}
	
	// Update is called once per frame
	void Update () {
		if(((Vector2)transform.position - startPos).sqrMagnitude > distance * distance)
			Destroy(gameObject);

		transform.Translate(dir * actualSpeed * Time.deltaTime);
	}
}
