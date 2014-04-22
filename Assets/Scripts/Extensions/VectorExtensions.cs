using UnityEngine;
using System.Collections;

public static class VectorExtensions {

	public static Vector2 Rotate2D(this Vector2 p, float theta){
		theta = Mathf.Deg2Rad * theta;
		return p.RotateAround2D(Vector2.zero, theta);
	}

	public static Vector2 RotateAround2D(this Vector2 p, Vector2 o, float theta){
		return new Vector2(Mathf.Cos(theta) * (p.x - o.x) - Mathf.Sin(theta) * (p.y - o.y) + o.x,
							Mathf.Sin(theta) * (p.x - o.x) + Mathf.Cos(theta) * (p.y - o.y) + o.y);
	}
}
