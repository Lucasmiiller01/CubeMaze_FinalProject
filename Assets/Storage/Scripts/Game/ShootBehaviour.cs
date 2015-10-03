using UnityEngine;
using System.Collections;

public class ShootBehaviour : MonoBehaviour {

	void Start () {
		StartCoroutine(Detonate());
	}
	IEnumerator Detonate()
	{
		yield return new WaitForSeconds(3f);
		Destroy(this.gameObject);
	}
	void Update () {
		rigidbody.velocity = transform.forward * 3;
	}
}
