using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerSphereFade : MonoBehaviour {
	public void TriggerSphereFading(){
		Toolbox.FindRequiredComponent<EventSystem> ().PlayNextEvent ();
	}
}