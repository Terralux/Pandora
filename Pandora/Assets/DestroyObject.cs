using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObject : BaseEvent {

	public Object objectToDestroy;


	#region implemented abstract members of BaseEvent
	public override void Action ()
	{
		Destroy (objectToDestroy);
	}
	#endregion
}
