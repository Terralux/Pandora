using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySoundEvent : BaseEvent {
	
	#region implemented abstract members of BaseEvent
	public override void Action ()
	{
		GetComponent<AudioSource> ().PlayDelayed (19f);
	}
	#endregion

	// Use this for initialization
	void Awake () {
		Toolbox.RegisterEvent<PlaySoundEvent> (this);
	}
}