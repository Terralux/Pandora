using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerEndSequence : MonoBehaviour {

	public void Trigger(){
		Toolbox.FindRequiredComponent<EventSystem> ().PlayNextEvent ();
	}
}
