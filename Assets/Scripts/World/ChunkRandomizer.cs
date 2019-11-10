﻿using System.Collections;
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

	static float difficultyScale = 1f;

	void Start()
    {
		difficultyScale += 0.1f;
		Debug.Log(difficultyScale);

		foreach (GameObject hotspot in obstacleHotspots)
		{
			if (Random.Range(0, 100) < obstacleChance * difficultyScale)
			{
				Instantiate(obstaclePrefabs[Random.Range(0, obstaclePrefabs.Count)], hotspot.transform.position, Quaternion.identity);
			}
			else if (Random.Range(0, 100) < milkChance * difficultyScale)
			{
				Instantiate(milkPrefab, hotspot.transform.position, Quaternion.identity);
			}
		}

		foreach (GameObject hotspot in moneyHotspots)
		{
			if (Random.Range(0, 100) < moneyChance * difficultyScale)
			{
				Instantiate(moneyPrefab, hotspot.transform.position, Quaternion.identity);
			}
		}
    }

	private void FixedUpdate()
	{

	}
}
