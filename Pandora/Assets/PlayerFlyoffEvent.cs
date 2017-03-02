using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFlyoffEvent : BaseEvent {

	private Transform target;

	private bool isActive = false;
	private float fraction;

	public float speed = 0.02f;

	// Use this for initialization
	void Awake () {
		Toolbox.RegisterEvent<PlayerFlyoffEvent> (this);
	}
	
	// Update is called once per frame
	void Update () {
		if (isActive) {
			if (fraction < 1) {
				fraction += Time.deltaTime * 0.01f;
			}
			if (target != null) {
				Vector3 relativePos = target.position - transform.position;
				Quaternion rotation = Quaternion.LookRotation (relativePos);

				transform.rotation = Quaternion.Lerp (transform.rotation, rotation, fraction);
				transform.position = transform.position + transform.forward * speed;
			}
		}
	}

	#region implemented abstract members of BaseEvent

	public override void Action ()
	{
		isActive = true;
		target = GameObject.FindGameObjectWithTag ("HomingTarget").transform;
		StartCoroutine (WaitForLanding ());
	}

	#endregion

	IEnumerator WaitForLanding(){
		yield return new WaitForSeconds (8f);
		Toolbox.FindRequiredComponent<EventSystem> ().PlayNextEvent ();
		yield return new WaitForSeconds (3f);
		Toolbox.FindRequiredComponent<EventSystem> ().PlayNextEvent ();
	}
}