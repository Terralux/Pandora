using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerLandingState : MonoBehaviour {

	public AnimationHandler animHandler;

	private Animator anim;

	void Awake(){
		anim = GetComponent<Animator> ();
		StartCoroutine (WaitForFlightAnim ());
	}

	public void TriggerLanding(){
		animHandler.UpdateAnimState (AnimationHandler.AnimationState.LAND);
	}

	IEnumerator WaitForFlightAnim(){
		yield return new WaitForSeconds(anim.GetCurrentAnimatorStateInfo (0).length);
		Toolbox.FindRequiredComponent<EventSystem> ().PlayNextEvent ();
	}
}