using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
	public Transform[] spawnPoints;
	public GameObject[] monsters;
	int randomSpawnPoint, randomMonster;
	public static bool spawnAllowed;
    public float TimeRespawn=2f;
	// Use this for initialization
	void Start () {
		spawnAllowed = true;
		InvokeRepeating (nameof(SpawnAMonster), 0f, TimeRespawn);
	}

	void SpawnAMonster()
	{
		if (spawnAllowed) {
			randomSpawnPoint = Random.Range (0, spawnPoints.Length);
			randomMonster = Random.Range (0, monsters.Length);
			Instantiate (monsters [randomMonster], spawnPoints [randomSpawnPoint].position,
				Quaternion.identity);
		}
	}
}
