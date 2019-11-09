using UnityEngine;

public class CameraFollow : MonoBehaviour
{
	public float followSpeed = 2f;
	public Transform followTarget;

	void FixedUpdate()
    {
		Vector3 newPosition = followTarget.position;
		newPosition.z = -10f;
		newPosition.y += 2f;
		transform.position = Vector3.Slerp(transform.position, newPosition, followSpeed * Time.deltaTime);
    }
}
