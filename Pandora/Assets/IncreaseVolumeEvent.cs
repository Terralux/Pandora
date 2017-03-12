using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IncreaseVolumeEvent : MonoBehaviour {

	private bool isIncreasingVolume;
	private AudioSource audioSource;

	void Awake () {
		audioSource = GetComponent<AudioSource> ();
	}

	void Update(){
		if (isIncreasingVolume) {
			audioSource.volume += Time.deltaTime;

			if (audioSource.volume == 1) {
				Destroy (this);
			}
		}
	}

	public void Action ()
	{
		isIncreasingVolume = true;
	}
}