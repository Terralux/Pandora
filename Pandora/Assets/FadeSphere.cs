using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeSphere : BaseEvent {

	public float delayBeforeActivation = 4f;
	public float fadeSlowDownFactor = 1f;

	private bool isFading = false;
	private float currentFadeValue = 0f;

	void Awake(){
		Toolbox.RegisterEvent<FadeSphere> (this);
	}

	void Update(){
		if (isFading) {
			currentFadeValue -= Time.deltaTime/fadeSlowDownFactor;
			GetComponent<MeshRenderer> ().material.color = new Color (0, 0, 0, currentFadeValue);

			if (currentFadeValue <= 0.05f) {
				Toolbox.FindRequiredComponent<EventSystem> ().PlayNextEvent ();
				Destroy (gameObject);
			}
		}
	}

	#region implemented abstract members of BaseEvent
	public override void Action ()
	{
		StartCoroutine (WaitForDelay ());
	}
	#endregion

	IEnumerator WaitForDelay(){
		yield return new WaitForSeconds (delayBeforeActivation);
		isFading = true;
		currentFadeValue = 1f;
	}
	
}