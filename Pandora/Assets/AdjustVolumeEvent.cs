using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdjustVolumeEvent : BaseEvent {

	public float volumeLevel = 0.1f;
	private AudioSource audioSource;

	#region implemented abstract members of BaseEvent
	public override void Action ()
	{
		StartCoroutine (AdjustSoundLevel ());
	}
	#endregion

	void Awake () {
		audioSource = GetComponent<AudioSource> ();
		Toolbox.RegisterEvent<AdjustVolumeEvent> (this);
	}

	IEnumerator AdjustSoundLevel(){
		yield return new WaitForSeconds (0.01f);
		audioSource.volume += (volumeLevel - audioSource.volume) * 0.01f;

		if (audioSource.volume - 0.02f >= volumeLevel) {
			StartCoroutine (AdjustSoundLevel ());
		}
	}
}
