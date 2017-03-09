using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerSphereFade : MonoBehaviour {
	public void Trigger(){
		Toolbox.FindRequiredComponent<EventSystem> ().PlayNextEvent ();
	}
}