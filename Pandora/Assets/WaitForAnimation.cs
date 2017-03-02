using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaitForAnimation : BaseEvent {

	private Animator anim;

	#region implemented abstract members of BaseEvent
	public override void Action (){
		StartCoroutine (WaitForExplosion ());
	}
	#endregion

	IEnumerator WaitForExplosion(){
		yield return new WaitForSeconds(anim.GetCurrentAnimatorStateInfo (0).length);
		Toolbox.FindRequiredComponent<EventSystem> ().PlayNextEvent ();
	}
}