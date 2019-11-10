using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
	public float movementSpeed = 3f;
	private float defaultSpeed;
	public Transform player;

	private void Start()
	{
		defaultSpeed = movementSpeed;
	}

	private void FixedUpdate()
	{
		transform.Translate(Vector2.right * Time.deltaTime * movementSpeed);

		if (Vector3.Distance(this.transform.position, player.transform.position) > 20)
		{
			movementSpeed = defaultSpeed + 0.5f;
		}
		else
		{
			movementSpeed = defaultSpeed;
		}
	}
}
