using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerAnimationEvent : BaseEvent {

	public string triggerName;
	private Animator anim;

	public AnimationClip animToWaitFor;

	void Awake() {
		Toolbox.RegisterEvent<TriggerAnimationEvent> (this);
	}

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
	}

	#region implemented abstract members of BaseEvent

	public override void Action ()
	{
		anim.SetTrigger (triggerName);
		StartCoroutine (WaitForExplosion ());
	}

	#endregion

	IEnumerator WaitForExplosion(){
		yield return new WaitForSeconds (animToWaitFor.length);
		Toolbox.FindRequiredComponent<EventSystem> ().PlayNextEvent ();
	}
}