using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
	public float movementSpeed = 3f;
	public static float staticMovementSpeed;
	public float jumpForce = 8f;
	public float milkBoostForce = 16f;
	public float poopSlowTime = 2f;
	public Rigidbody2D rb;
	public Transform groundCheck;
	public LayerMask groundLayer;
    public Text countText;
	public GameObject tootCloud;

	private bool isGrounded;
	private bool isSlowed;
	private bool readyToIncrease;
	private float savedSpeed;
    public static int Money;

    private void Start()  //This states that, once the game begins, it will start to count 
    {
		readyToIncrease = true;
        Money = 1000;
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
		if (readyToIncrease)
		{
			StartCoroutine(MovementIncrease());
			readyToIncrease = false;
		}
	}

    void OnTriggerEnter2D(Collider2D other) //This is the code for the "Pickups" objects
    {
		if (!isSlowed)
		{
			staticMovementSpeed = movementSpeed;
		}

        if (other.gameObject.CompareTag("Money"))
        {
			Destroy(other.gameObject);
            Money += 100;
            SetCountText();
        }
		else if (other.tag == "Milk")
		{
			Destroy(other.gameObject);
			Vector2 jumpVector = new Vector2(milkBoostForce, milkBoostForce);
			rb.AddForce(jumpVector, ForceMode2D.Impulse);
			StartCoroutine(TootCloud());
		}
		else if (other.tag == "Poop")
		{
			if (!isSlowed)
			{
				StartCoroutine(PoopSlow());
				isSlowed = true;
			}
		}
		else if (other.tag == "Enemy")
		{
			Debug.Log("Game Over");
			SceneManager.LoadScene("Game Over Screen Scene");
		}
    }

	void SetCountText()
    {
        countText.text = $"Cash: {Money.ToString()}";
    }

	IEnumerator TootCloud()
	{
		tootCloud.SetActive(true);
		yield return new WaitForSeconds(1);
		tootCloud.SetActive(false);
	}

	IEnumerator MovementIncrease()
	{
		yield return new WaitForSeconds(10);
		Debug.Log($"Speed: {movementSpeed}");
		movementSpeed += 0.25f;
		readyToIncrease = true;
	}

	IEnumerator PoopSlow()
	{
		var savedSpeed = movementSpeed;
		movementSpeed -= (movementSpeed / 1.5f);
		yield return new WaitForSeconds(poopSlowTime);
		movementSpeed = savedSpeed;
		isSlowed = false;
	}
}