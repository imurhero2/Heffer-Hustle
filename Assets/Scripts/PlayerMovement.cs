using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	public float movementSpeed;

	private void Start()
	{

	}

	private void FixedUpdate()
	{
		transform.Translate(Vector2.right * Time.deltaTime * movementSpeed);
	}
}
