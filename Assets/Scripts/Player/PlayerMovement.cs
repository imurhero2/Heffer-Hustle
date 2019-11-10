using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
	public float movementSpeed = 3f;
	public float jumpForce = 8f;
	public float milkBoostForce = 16f;
	public Rigidbody2D rb;
	public Transform groundCheck;
	public LayerMask groundLayer;
    public TMP_Text countText;
	public GameObject tootCloud;

	private bool isGrounded;
    public static int count;

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
        if (other.gameObject.CompareTag("Money"))
        {
			Destroy(other.gameObject);
            count += 100;
            SetCountText();
        }
		else if (other.tag == "Milk")
		{
			Destroy(other.gameObject);
			Vector2 jumpVector = new Vector2(milkBoostForce, milkBoostForce);
			rb.AddForce(jumpVector, ForceMode2D.Impulse);
			StartCoroutine(TootCloud());
		}
		else if (other.tag == "Enemy")
		{
			SceneManager.LoadScene("Game Over Screen Scene");
		}
    }

    void SetCountText()
    {
        countText.text = $"Cash: {count.ToString()}";
    }

	IEnumerator TootCloud()
	{
		tootCloud.SetActive(true);
		yield return new WaitForSeconds(2);
		tootCloud.SetActive(false);
	}
}