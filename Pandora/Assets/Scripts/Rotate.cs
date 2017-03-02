using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : BaseEvent {

	[Range(0,5)]
	public float rotationSpeed;

	public float xRotationLimit = 90f;

	private bool isPlaying = false;

	void Awake(){
		Toolbox.FindRequiredComponent<EventSystem> ().PlayNextEvent ();
		Toolbox.RegisterEvent<BaseEvent> (this);
	}

	void Update () {
		if (isPlaying) {
			if (transform.rotation.eulerAngles.x < xRotationLimit || transform.rotation.eulerAngles.x > 300) {
				transform.Rotate (Vector3.right * Time.deltaTime * rotationSpeed);
			} else {
				//Toolbox.FindRequiredComponent<EventSystem> ().PlayNextEvent ();
				//Destroy (this);
			}
		}
	}

	#region implemented abstract members of BaseEvent

	public override void Action ()
	{
		isPlaying = true;
	}

	#endregion
}