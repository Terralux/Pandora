using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdSpawner : BaseEvent {

	public GameObject birdModel;

	public Transform target;

	void Awake (){
		Toolbox.RegisterEvent<BirdSpawner> (this);
	}

	#region implemented abstract members of BaseEvent

	public override void Action ()
	{
		GameObject go = Instantiate (birdModel, target.position, Quaternion.identity) as GameObject;
		go.GetComponentInChildren<AnimationHandler> ().UpdateAnimState (AnimationHandler.AnimationState.TAKEOFF);
	}

	#endregion
}
