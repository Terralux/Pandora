using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeOffEvent : BaseEvent {

	public float speed;

	private bool isActive = false;

	private Vector3 target;

	private float fraction;

	// Use this for initialization
	void Start () {
		Toolbox.RegisterEvent<TakeOffEvent> (this);
	}
	
	// Update is called once per frame
	void LateUpdate () {
		if (isActive) {
			if (fraction < 1) {
				fraction += Time.deltaTime * 0.01f;
			}

			Vector3 relativePos = target - transform.position;
			Quaternion rotation = Quaternion.LookRotation(relativePos);

			transform.rotation = Quaternion.Lerp(transform.rotation, rotation, fraction);
			transform.position = transform.position + transform.forward * speed;
		}
	}

	#region implemented abstract members of BaseEvent

	public override void Action ()
	{
		isActive = true;
		Vector3 pos = transform.position;
		Destroy (GetComponent<Animator> ());

		transform.position = pos;

		target = transform.position + new Vector3 (0, 40, -100);
	}

	#endregion
}
