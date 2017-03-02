using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaitForTimer : MonoBehaviour {

	public float timer = 5f;

	// Use this for initialization
	void Start () {
		StartCoroutine (WaitForTimerToEnd ());
	}

	IEnumerator WaitForTimerToEnd(){
		yield return new WaitForSeconds(timer);
		Toolbox.FindRequiredComponent<EventSystem> ().PlayNextEvent ();
	}
}