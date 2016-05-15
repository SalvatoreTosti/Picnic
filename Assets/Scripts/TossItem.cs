using UnityEngine;
using System.Collections;

public class TossItem : MonoBehaviour {

//	public Camera camera;
	public GameObject worldPrefab;
	public float speed;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetButtonDown("Fire3")){
			Debug.Log ("tossing item");
			GameObject obj = (GameObject) Instantiate (worldPrefab,transform.parent.position,transform.parent.rotation);
			obj.GetComponent<GunPickup> ().SpawnLocation = transform.parent.transform;
			obj.GetComponent<Rigidbody> ().AddForce (transform.parent.forward * speed);
			Destroy (gameObject);
		}
	}
}
