using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventSystem : MonoBehaviour {

	public delegate void voidEvent();

	public int currentEventCount = 0;

	public List<voidEvent> myVoidEvents = new List<voidEvent>();
	private voidEvent templateEvent;

	void Start(){
		myVoidEvents.Clear ();
		myVoidEvents.Add (templateEvent);
		int count = 0;
		for(int i = 0; i < Toolbox.Instance.registeredEvents.Count; i++){
			if (Toolbox.Instance.registeredEvents [i].eventTriggerIndex == myVoidEvents.Count - 1) {
				myVoidEvents [count] += Toolbox.Instance.registeredEvents [i].Action;
			} else {
				myVoidEvents.Add (templateEvent);
				count++;
				myVoidEvents [count] += Toolbox.Instance.registeredEvents [i].Action;
			}
		}
	}

	public void PlayNextEvent(){
		Start ();
		if (currentEventCount < myVoidEvents.Count) {
			if (myVoidEvents [currentEventCount] != null) {
				Debug.Log ("Triggered an event");
				myVoidEvents [currentEventCount] ();
				currentEventCount++;
			}
		}
	}
}