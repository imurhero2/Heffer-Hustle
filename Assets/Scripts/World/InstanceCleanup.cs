using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstanceCleanup : MonoBehaviour
{
	private void Start()
	{
		StartCoroutine(CleanUp());
	}

	IEnumerator CleanUp()
	{
		yield return new WaitForSeconds(15);
		Destroy(this.gameObject);
	}
}