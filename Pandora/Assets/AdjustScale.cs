using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdjustScale : MonoBehaviour {

	public float adjustment;
	private Vector3 origin;

	// Use this for initialization
	void Awake () {
		origin = transform.localScale;
	}
	
	// Update is called once per frame
	void LateUpdate () {
		transform.localScale = origin * adjustment;
	}
}
