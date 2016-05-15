using UnityEngine;
using System.Collections;

public class GunPickup : MonoBehaviour {

	public GameObject HandGunPrefab;
	public Transform SpawnLocation;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown ("Fire2")) {
			Pickup ();
		}
	}

	void Pickup(){
		GameObject obj = (GameObject)Instantiate (HandGunPrefab, new Vector3 (0, 0, 0), Quaternion.Euler (0, 0, 0));
		obj.transform.parent = SpawnLocation;
		//obj.GetComponent<Rigidbody> ().AddForce (camera.transform.forward * speed);
		Destroy (gameObject);
	}
}
