using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioEvent : BaseEvent  {

	void Awake () {
		Toolbox.RegisterEvent<AudioEvent> (this);
	}

	public override void Action () {
		StartCoroutine (WaitForAnimationStop ());
	}

	IEnumerator WaitForAnimationStop (){
		//GetComponent<AudioSource> ().Play ();
		yield return new WaitForSeconds (10f);
		GetComponent<Animator> ().SetTrigger ("ACTION");
	}
}