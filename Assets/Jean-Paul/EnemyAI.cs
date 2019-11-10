using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
	public float movementSpeed = 3f;
	public Transform player;

	private void FixedUpdate()
	{
		transform.Translate(Vector2.right * Time.deltaTime * movementSpeed);

		if (Vector3.Distance(this.transform.position, player.transform.position) > 20)
		{
			movementSpeed = PlayerMovement.staticMovementSpeed;
		}
		else
		{
			movementSpeed = Mathf.Clamp(PlayerMovement.staticMovementSpeed, 0, 5) - 0.5f;
		}
	}
}