using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Homing : MonoBehaviour {

	private Transform target;

	public float speed;
	public float xOffset = 10f;
	public bool isUsingRightOffset = true;

	public float distanceLimit = 5f;

	private Rigidbody rb;

	private bool hasTriggeredEvent = false;

	void Awake () {
		rb = GetComponent<Rigidbody> ();
		target = GameObject.FindGameObjectWithTag ("HomingTarget").transform;
	}

	void Update () {
		if (!hasTriggeredEvent) {
			if (isUsingRightOffset && Vector3.Distance (target.position, transform.position) < distanceLimit) {
				Toolbox.FindRequiredComponent<EventSystem> ().PlayNextEvent ();
				hasTriggeredEvent = true;
			}
		}

		transform.LookAt (target.position + target.forward * -1 * xOffset + (target.right * xOffset * (isUsingRightOffset? 1:-1)));

		rb.velocity = transform.forward * speed;
	}
}