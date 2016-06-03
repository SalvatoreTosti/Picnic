using UnityEngine;
using System.Collections;

public class WeaponHandling : MonoBehaviour {
	/* Handles picking up and putting down weapons. */
	public float speed = 100.0f;
	public float pickupRadius = 2.0f;
	public Transform SpawnLocation;
	public GameObject FirstPersonWeapon;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown ("Fire2")) {
			Collider[] hitColliders = Physics.OverlapSphere (transform.position, pickupRadius);
			foreach (Collider collider in hitColliders) {
				GameObject child = collider.gameObject;
				GameObject obj;
				if (child.transform.transform.root != null) {
					obj = child.transform.root.gameObject;
				} else {
					obj = child;
				}
				if (obj.tag == "Weapon" && FirstPersonWeapon == null) {
					GameObject weapon = (GameObject)Instantiate (
						                    obj.GetComponent<Pickupable> ().FirstPersonPrefab, 
						                    SpawnLocation.position,
						                    SpawnLocation.rotation);
					FirstPersonWeapon = weapon;
					weapon.transform.parent = SpawnLocation;
					Destroy (obj); //destroy world copy of object
				}
			}
		} else if (Input.GetButtonDown ("Fire3")) {
			if (FirstPersonWeapon != null) {
				GameObject obj = (GameObject) Instantiate (
					FirstPersonWeapon.GetComponent<Tossable> ().worldPrefab,
					transform.position,
					transform.rotation);
				obj.GetComponent<Rigidbody> ().AddForce (transform.forward * speed);
				Destroy (FirstPersonWeapon);
			}
		} else {
			
		}
//					elseif
//			GameObject obj = (GameObject) Instantiate (worldPrefab,transform.parent.position,transform.parent.rotation);
//			obj.GetComponent<GunPickup> ().SpawnLocation = transform.parent.transform;
//			obj.GetComponent<Rigidbody> ().AddForce (transform.parent.forward * speed);
//			Destroy (gameObject);
		
	}
}


//	void Pickup(){
//		GameObject obj = (GameObject)Instantiate (HandGunPrefab, new Vector3 (0, 0, 0), Quaternion.Euler (0, 0, 0));
//		obj.transform.parent = SpawnLocation;
//		//obj.GetComponent<Rigidbody> ().AddForce (camera.transform.forward * speed);
//		Destroy (gameObject);
//	}

