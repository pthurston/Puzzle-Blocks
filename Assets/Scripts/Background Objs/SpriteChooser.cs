using UnityEngine;
using System.Collections;

[RequireComponent(typeof(SpriteRenderer))]
public class SpriteChooser : MonoBehaviour {

	public Sprite[] sprites;

	SpriteRenderer sRenderer;

	void Awake(){
		sRenderer = GetComponent<SpriteRenderer>();

		if(sprites.Length > 0){
			Debug.Log(sprites.Length);
			sRenderer.sprite = sprites[Random.Range(0, sprites.Length)];
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
