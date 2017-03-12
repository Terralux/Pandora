using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundtrackTrigger : MonoBehaviour {

	public IncreaseVolumeEvent ive;

	public void TriggerSoundtrack () {
		ive.Action ();
	}
}
