using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultipleBirdSpawner : BaseEvent {

	public GameObject homingBirdModel;

	public Transform target;

	void Awake (){
		Toolbox.RegisterEvent<MultipleBirdSpawner> (this);
	}

	#region implemented abstract members of BaseEvent

	public override void Action ()
	{
		GameObject go = Instantiate (homingBirdModel, target.position, Quaternion.identity) as GameObject;
		go.GetComponentInChildren<AnimationHandler> ().UpdateAnimState (AnimationHandler.AnimationState.TAKEOFF);

		go = Instantiate (homingBirdModel, target.position, Quaternion.identity) as GameObject;
		go.GetComponentInChildren<AnimationHandler> ().UpdateAnimState (AnimationHandler.AnimationState.TAKEOFF);
		go.GetComponent<Homing> ().isUsingRightOffset = false;
	}

	#endregion
}