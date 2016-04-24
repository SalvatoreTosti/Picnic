using UnityEngine;
using System.Collections;

public class TimedDestroy : MonoBehaviour {

	public float endTime = 1.0f;
	private float currentTime;
	// Use this for initialization
	void Start () {
		currentTime = 0.0f;
	}

	// Update is called once per frame
	void Update () {
		if (currentTime >= endTime) {
			Destroy (gameObject);
		} else {
			currentTime += Time.deltaTime;
		}
	}
}
