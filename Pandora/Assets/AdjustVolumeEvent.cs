using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdjustVolumeEvent : BaseEvent {

	public float volumeLevel = 0.1f;

	#region implemented abstract members of BaseEvent
	public override void Action ()
	{
		Invoke ("StartMyCoroutine", 15f);

	}
	#endregion

	void StartMyCoroutine(){
		StartCoroutine (AdjustSoundLevel ());
	}

	// Use this for initialization
	void Awake () {
		Toolbox.RegisterEvent<AdjustVolumeEvent> (this);
	}

	IEnumerator AdjustSoundLevel(){
		yield return new WaitForSeconds (0.01f);
		GetComponent<AudioSource> ().volume -= 0.01f;

		if (GetComponent<AudioSource> ().volume > volumeLevel) {
			StartCoroutine (AdjustSoundLevel ());
		}
	}
}
