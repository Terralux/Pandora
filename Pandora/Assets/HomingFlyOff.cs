using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomingFlyOff : BaseEvent {

	private bool isActive;

	private float fraction = 0;

	private Vector3 target;

	private Rigidbody rb;

	public float speed = 2;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
		Toolbox.RegisterEvent<HomingFlyOff> (this);
	}
	
	// Update is called once per frame
	void Update () {
		if (isActive) {
			if (fraction < 1) {
				fraction += Time.deltaTime * 0.01f;
			}

			Vector3 relativePos = target - transform.position;
			Quaternion rotation = Quaternion.LookRotation(relativePos);

			transform.rotation = Quaternion.Lerp(transform.rotation, rotation, fraction);
			rb.velocity = transform.forward * speed;
		}
	}

	#region implemented abstract members of BaseEvent

	public override void Action ()
	{
		isActive = true;
		target = transform.position + transform.forward * 500 + transform.up * 300;
		Destroy(GetComponent<Homing>());
	}

	#endregion
}
