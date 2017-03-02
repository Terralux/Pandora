using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudColorChangeEvent : BaseEvent {

	private CloudsToy clouds;

	private bool isActive = false;

	public float speed = 0.01f;

	public Color targetCloudColor;
	public Color targetMainColor;
	public Color targetSecondaryColor;

	private float fraction;

	// Use this for initialization
	void Awake () {
		Toolbox.RegisterEvent<CloudColorChangeEvent> (this);
		clouds = GetComponent<CloudsToy> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (isActive) {
			if (fraction < 1) {
				fraction += Time.deltaTime * speed;
			}

			clouds.CloudColor = Color.Lerp (clouds.CloudColor, targetCloudColor, fraction);
			clouds.MainColor = Color.Lerp (clouds.MainColor, targetMainColor, fraction);
			clouds.SecondColor = Color.Lerp (clouds.SecondColor, targetSecondaryColor, fraction);
		}
	}

	#region implemented abstract members of BaseEvent

	public override void Action ()
	{
		isActive = true;
	}

	#endregion
}
