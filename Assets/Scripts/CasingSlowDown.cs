using UnityEngine;
using System.Collections;

public class CasingSlowDown : MonoBehaviour {

	public float timeUntilSlowdown;
	private float currentTime;
	// Use this for initialization
	void Start () {
		currentTime = 0.0f;
	}
	
	// Update is called once per frame
	void Update () {
		if (currentTime >= timeUntilSlowdown) {
			GetComponent<Rigidbody> ().angularDrag = 100.0f;
		} else {
			currentTime += Time.deltaTime;
		}
	}
}
