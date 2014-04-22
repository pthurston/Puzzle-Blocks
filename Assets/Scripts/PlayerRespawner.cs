using UnityEngine;
using System.Collections;

public class PlayerRespawner : MonoBehaviour {

	public Transform respawnPoint;

	Transform player;

	Rect camBounds;

	// Use this for initialization
	void Awake () {
		player = GameObject.FindWithTag("Player").transform;
		Camera cam = Camera.main;
		camBounds = new Rect(transform.position.x - cam.orthographicSize * cam.aspect,
							transform.position.y - cam.orthographicSize,
							cam.orthographicSize * cam.aspect * 2,
							cam.orthographicSize * 2);
	}
	
	// Update is called once per frame
	void Update () {
		if(!respawnPoint)
			return; 
				
		if(Physics2D.OverlapArea(new Vector2(camBounds.x, camBounds.y), new Vector2(camBounds.x + camBounds.width, camBounds.y + camBounds.height), 1 << 8) == null){
			player.transform.position = respawnPoint.position;
		}	
	}
}
