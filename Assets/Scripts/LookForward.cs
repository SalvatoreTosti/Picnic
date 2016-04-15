using UnityEngine;
using System.Collections;

public class LookForward : MonoBehaviour {
	public Camera camera;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.forward = camera.transform.forward;
	}
}
