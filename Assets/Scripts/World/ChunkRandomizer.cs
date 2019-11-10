using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChunkRandomizer : MonoBehaviour
{
	public GameObject milkPrefab;
	public float milkChance;

	public List<GameObject> obstaclePrefabs;
	public List<GameObject> obstacleHotspots;
	public float obstacleChance;

	public GameObject moneyPrefab;
	public List<GameObject> moneyHotspots;
	public float moneyChance;

	void Start()
    {
		foreach (GameObject hotspot in obstacleHotspots)
		{
			if (Random.Range(0, 100) < obstacleChance)
			{
				Instantiate(obstaclePrefabs[Random.Range(0, obstaclePrefabs.Count)], hotspot.transform.position, Quaternion.identity);
			}
			else if (Random.Range(0, 100) < milkChance)
			{
				Instantiate(milkPrefab, hotspot.transform.position, Quaternion.identity);
			}
		}

		foreach (GameObject hotspot in moneyHotspots)
		{
			if (Random.Range(0, 100) < moneyChance)
			{
				Instantiate(moneyPrefab, hotspot.transform.position, Quaternion.identity);
			}
		}
    }

	private void FixedUpdate()
	{

	}
}
