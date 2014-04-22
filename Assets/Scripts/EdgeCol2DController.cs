using UnityEngine;
using System.Collections;

public class EdgeCol2DController : MonoBehaviour {

	public Sides[] edgeSides;

	EdgeCollider2D col;

	void Awake(){
		col = GetComponent<EdgeCollider2D>();
		Vector2 pos = (Vector2)transform.position;
		if(col){
			Vector2[] newPoints = new Vector2[edgeSides.Length * 2];
			for(int i = 0; i < edgeSides.Length; i++){
				switch(edgeSides[i]){
					case Sides.Top:
						newPoints[2 * i] = new Vector2(-0.5f, 0.5f);
						newPoints[2 * i + 1] = new Vector2(0.5f, 0.5f);
						break;
					case Sides.Bottom:
						newPoints[2 * i] = new Vector2(-0.5f, -0.5f);
						newPoints[2 * i + 1] = new Vector2(0.5f, -0.5f);
						break;
					case Sides.Left:
						newPoints[2 * i] = new Vector2(-0.5f, -0.5f);
						newPoints[2 * i + 1] = new Vector2(-0.5f, 0.5f);
						break;
					case Sides.Right:
						newPoints[2 * i] = new Vector2(0.5f, 0.5f);
						newPoints[2 * i + 1] = new Vector2(0.5f, -0.5f);
						break;
				}
			}
			col.points = newPoints;
		}
	}

	public enum Sides{
		Top,
		Bottom,
		Left,
		Right
	}
}
