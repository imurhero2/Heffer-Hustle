using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChunkRandomizer : MonoBehaviour
{
	public List<GameObject> obstaclePrefabs;
	public List<GameObject> obstacleHotspots;

	void Start()
    {
		foreach (GameObject hotspot in obstacleHotspots)
		{
			if (Random.Range(0, 100) > 50)
			{
				Instantiate(obstaclePrefabs[Random.Range(0, obstaclePrefabs.Count)], hotspot.transform.position, Quaternion.identity);
			}
		}
    }
}
