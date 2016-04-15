using UnityEngine;
using System.Collections;

public class Interaction : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

//	public void DoInteraction(){
//		//GetComponent<RotateAround> ().nextAction();
//	}

	public void DoInteraction(Transform trans){
		GetComponent<RotateAround> ().nextAction (trans);
	}
}
