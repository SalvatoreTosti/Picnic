using UnityEngine;
using System.Collections;

public class BulletTravel : MonoBehaviour {

	public float speed = 1.0f;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		Rigidbody body = GetComponent<Rigidbody> ();
		body.AddForce (transform.forward * speed);
	}
}
