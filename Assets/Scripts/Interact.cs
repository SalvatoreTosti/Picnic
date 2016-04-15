using UnityEngine;
using System.Collections;

public class Interact : MonoBehaviour {
	public float interactionRadius = 2;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetButtonDown("Interact")){
			Collider[] hitColliders = Physics.OverlapSphere (transform.position, interactionRadius);
			foreach (Collider collider in hitColliders) {
				GameObject obj = collider.gameObject;
				if (obj.tag == "Interactable") {
					obj.GetComponent<Interaction> ().DoInteraction(transform.parent.transform);
				} else {
					//do nothing
				}
			}
		}
	}
		
}
