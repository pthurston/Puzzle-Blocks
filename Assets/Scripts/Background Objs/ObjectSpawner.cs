using UnityEngine;
using System.Collections;

[RequireComponent(typeof(BoxCollider2D))]
public class ObjectSpawner : MonoBehaviour {

	public Transform[] objects;

	public float spawnRate = 3.0f;
	public float spawnRateDeviation = 1.0f;

	float nextSpawnTime;

	BoxCollider2D col;

	void Awake(){
		nextSpawnTime = TimeToNextSpawn();
		col = GetComponent<BoxCollider2D>();
	}
	
	// Update is called once per frame
	void Update () {
		if(nextSpawnTime < Time.time){
			SpawnRandomObject();
		}
	}

	void SpawnRandomObject(){
		if(objects.Length == 0)
			return;

		Transform obj = objects[Random.Range(0, objects.Length)];
		Vector2 pos = new Vector2(col.center.x + Random.Range(-col.size.x, col.size.x) / 2.0f, col.center.y + Random.Range(-col.size.y, col.size.y) / 2.0f);

		Instantiate(obj, pos + (Vector2)transform.position, Quaternion.identity);

		nextSpawnTime += TimeToNextSpawn();
	}

	float TimeToNextSpawn(){
		return spawnRate + Random.Range(-spawnRateDeviation, spawnRateDeviation);
	}
}
