using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using TMPro;

public class PlayerMovement : MonoBehaviour
{
	public float movementSpeed = 3f;
	public float jumpForce = 8f;
	public Rigidbody2D rb;
	public Transform groundCheck;
	public LayerMask groundLayer;
    public TMP_Text countText;

	private bool isGrounded;
    private int count;

    private void Start()  //This states that, once the game begins, it will start to count 
    {
        count = 0;
        SetCountText();
    }

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

    void OnTriggerEnter2D(Collider2D other) //This is the code for the "Pickups" objects
    {
        if (other.gameObject.CompareTag("Pickups"))
        {

            other.gameObject.SetActive(false);
            count = count + 100;
            SetCountText();
        }
    }

    void SetCountText()
    {
        
        countText.text = $"Cash: {count.ToString()}";
    }



}
