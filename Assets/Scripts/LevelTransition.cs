using UnityEngine;
using System.Collections;

public class LevelTransition : MonoBehaviour {

	public float panOffset = 12.0f;

	bool readyToEnd = false;

	string sceneToLoad = "";

	void Start(){
		transform.position = transform.position + Vector3.up * panOffset;
		GetComponent<Tween2D>().MoveByOffset(-Vector2.up * panOffset, 1.0f);
	}

	public void EndLevel(string nextLevel){
		sceneToLoad = nextLevel;
		Debug.Log("End");
		GetComponent<Tween2D>().MoveByOffset(Vector2.up * panOffset, 1.0f);
		readyToEnd = true;
	}

    public void OnArrival(){         
    	if(readyToEnd){
    		Debug.Log((string)sceneToLoad);
			Application.LoadLevel(sceneToLoad);
		}
	}
}
