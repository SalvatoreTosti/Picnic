using UnityEngine;
using System.Collections;

public class RotationTest : MonoBehaviour {
	public float rotAmount;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void FixedUpdate(){
		GetComponent<Rigidbody> ().AddTorque (Vector3.up * rotAmount);//Random.Range (-200.0f, 200.0f));
	}
}
