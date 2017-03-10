using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyinAnim : BaseEvent {

	public string triggerName;
	private Animator anim;
	public float animDelay = 0f;



	void Awake() {
		Toolbox.RegisterEvent<FlyinAnim> (this);
	}

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
	}

	#region implemented abstract members of BaseEvent

	public override void Action ()
	{
		anim.SetTrigger (triggerName);


			StartCoroutine (WaitForFade ());

	}

	#endregion

	IEnumerator WaitForFade(){
		yield return new WaitForSeconds (animDelay);
		Toolbox.FindRequiredComponent<EventSystem> ().PlayNextEvent ();
	}
}