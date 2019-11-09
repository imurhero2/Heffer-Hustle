using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	public float movementSpeed = 3f;
	public float jumpForce = 8f;
	public Rigidbody2D rb;
	public Transform groundCheck;
	public LayerMask groundLayer;
	private bool isGrounded;

	private void Update()
	{
		isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.15f, groundLayer);

		if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
		{
			Vector2 jumpVector = new Vector2(0, jumpForce);
			rb.AddForce(jumpVector, ForceMode2D.Impulse);
		}
	}

	private void FixedUpdate()
	{
		transform.Translate(Vector2.right * Time.deltaTime * movementSpeed);
	}
}
