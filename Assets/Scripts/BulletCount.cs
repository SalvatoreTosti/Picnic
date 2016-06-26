using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BulletCount : MonoBehaviour {

	public int currentBullets;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		Text GUICounter = this.GetComponent<Text> ();
		GUICounter.text = currentBullets.ToString();
	}

	public void setCurrentBullets(int newAmount){
		currentBullets = newAmount;
	}
}
