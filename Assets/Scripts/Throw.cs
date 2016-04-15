using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Throw : MonoBehaviour {

	public GameObject item;
	public Camera camera;
	public float speed;
	public Queue<GameObject> throwableItems = new Queue<GameObject> ();
	public float itemCount;

	// Use this for initialization
	void Start () {
//		for (int i = 0; i < 5; i++) {
//			throwableItems.Enqueue (item);
//		}
	}
	
	// Update is called once per frame
	void Update () {
		itemCount = throwableItems.Count;

		if (Input.GetButtonDown ("Fire1")){
			if(throwableItems.Count > 0) {
				//GameObject obj = (GameObject)Instantiate (throwableItems.Dequeue(), transform.position, transform.parent.rotation);
				GameObject obj = throwableItems.Dequeue();
				obj.transform.position = transform.position;
				obj.transform.rotation = transform.parent.rotation;
				obj.active = true;
				obj.GetComponent<Rigidbody> ().AddForce (camera.transform.forward * speed);
				//Vector3 randomVector = new Vector3 (Random.Range(-200,200), Random.Range(-200,200), Random.Range(-200,200));
				obj.transform.Rotate(Random.rotation.eulerAngles);
//				obj.GetComponent<Rigidbody>().AddTorque(Random.rotation.eulerAngles);

			} else {
				Debug.Log ("Attempted to throw when itemCount <= 0");
			}
		}else{
			//do nothing
		}
	}

	public void addItem(GameObject item){
		throwableItems.Enqueue (item);
	}



}
