using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PandoraLogoActivation : MonoBehaviour {

	public float waitForStart = 5f;

	void Awake(){
		StartCoroutine (WaitForStartUp ());
	}

	IEnumerator WaitForStartUp (){
		yield return new WaitForSeconds (waitForStart);
		GetComponent<Animator> ().SetTrigger ("ACTION");
	}

}
