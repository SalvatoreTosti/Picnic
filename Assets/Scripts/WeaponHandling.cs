using UnityEngine;
using System.Collections;

public class WeaponHandling : MonoBehaviour {
	/* Handles picking up and putting down weapons. */
	public float speed = 100.0f;
	public float pickupRadius = 2.0f;
	public Transform SpawnLocation;
	public GameObject FirstPersonWeapon;
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown ("Fire2")) {
			if (FirstPersonWeapon == null) {
				PickUp ();
			}
		} else if (Input.GetButtonDown ("Fire3")) {
			if (FirstPersonWeapon != null) {
				Drop (); 
			}
		} else {
			//do nothing
		}
	}

	private void Drop(){
		GameObject obj = (GameObject) Instantiate (
			FirstPersonWeapon.GetComponent<Tossable> ().worldPrefab,
			transform.position,
			transform.rotation);
		obj.GetComponent<Rigidbody> ().AddForce (transform.forward * speed);
		Destroy (FirstPersonWeapon); //destroy hand copy of object
		
	}

	private void PickUp(){
		/**
		 * Attempts to pick up a "Weapon" GameObject witin pickupRadius.
		 */
		ArrayList weapons = getWeaponsInArea ();
		if(weapons.Count > 0){ //if there are any weapons in the area
			GameObject weapon = (GameObject) weapons[0];
			FirstPersonWeapon = (GameObject)Instantiate (
				weapon.GetComponent<Pickupable> ().FirstPersonPrefab, 
				SpawnLocation.position,
				SpawnLocation.rotation);;
			FirstPersonWeapon.transform.parent = SpawnLocation;
			Destroy (weapon); //destroy world copy of object
		}
	}

	private ArrayList getWeaponsInArea(){
		/**
		 * Returns a list of GameObjects which are in the pickupRadius and have the tag "Weapon"
		 */
		ArrayList weapons = new ArrayList ();
		Collider[] hitColliders = Physics.OverlapSphere (transform.position, pickupRadius);
		foreach (Collider collider in hitColliders) {
			GameObject obj = collider.transform.root.gameObject;
			if (obj.tag == "Weapon") {
				weapons.Add (obj);
			}
		}
		return weapons;
	}

}

