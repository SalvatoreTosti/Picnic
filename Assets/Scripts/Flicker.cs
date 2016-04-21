using UnityEngine;
using System.Collections;

public class Flicker : MonoBehaviour {


	public float maxStateDuration = 10.0f;
	public int stateSwapThreshold = 60;
	private float currentStateDuration;
	public int lastRandomRoll = 0;
	private bool lightOn;

	private float originalIntensity;

	// Use this for initialization
	void Start () {
		originalIntensity = GetComponent<Light> ().intensity;
		currentStateDuration = 0.0f;
	}
	
	// Update is called once per frame
	void Update () {
		lastRandomRoll = Random.Range (0, 100);
		if(lastRandomRoll >= stateSwapThreshold){
			flipLight ();
			currentStateDuration = 0;
		} else {
			currentStateDuration += Time.deltaTime;
		}
		if (currentStateDuration >= maxStateDuration) {
			flipLight ();
			currentStateDuration = 0;
		}

	}

	private void flipLight(){
		if (lightOn) {
			flipLightOff ();
		} else {
			flipLightOn();
		}
	}

	private void flipLightOff(){
		GetComponent<Light> ().intensity = 0;
		lightOn = false;
	}

	private void flipLightOn(){
		GetComponent<Light> ().intensity = originalIntensity;
		lightOn = true;
	}
}
