﻿using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ChunkSpawner : MonoBehaviour
{
	[SerializeField] private GameObject chunkPrefab;
	public GameObject gameChunkParent;
	public Transform player;

	void Start()
    {

	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		Vector3 spawnLocation =  gameChunkParent.transform.position + new Vector3(30f, 0, 0);
		var newChunk = Instantiate(chunkPrefab, spawnLocation, Quaternion.identity);
		newChunk.name = "GameChunk";
	}

	private void FixedUpdate()
	{
		if (Vector3.Distance(this.transform.position, player.transform.position) > 50)
		{
			Destroy(gameChunkParent);
		}
	}
}