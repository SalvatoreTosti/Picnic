using UnityEngine;
using System.Collections;

public class Reload : MonoBehaviour {
	private Animator animator;

	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButton ("Reload")) {
			ReloadWeapon ();
		}
	}

	private void ReloadWeapon(){
		Debug.Log ("Reloading");
		animator.SetBool ("Reloading",true);
	}

	public void ReloadAdjust(){
		//magazineCount = maxMagazineCount;
		Debug.Log ("Reloaded");
		animator.SetBool ("Reloading",false);
	}
}
