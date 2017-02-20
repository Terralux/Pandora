using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationHandler : MonoBehaviour {

	public enum AnimationState{
		LAND,
		IDLE,
		FLAP,
		TAKEOFF,
		FLY
	}

	private Animator anim;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
	}

	public void UpdateAnimState(AnimationState newState){
		if (anim == null) {
			anim = GetComponent<Animator> ();
		}
		anim.SetTrigger (newState.ToString());
	}
}