using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseEvent : MonoBehaviour, IComparable<BaseEvent> {
	public int eventTriggerIndex = 0;

	#region IComparable implementation
	/// <summary>
	/// Compares the current object with another object of the same type.
	/// </summary>
	/// <returns>Above 0 if the object is larger or less than 0 if not</returns>
	/// <param name="other">The other object.</param>
	public int CompareTo (BaseEvent other)
	{
		if (other.eventTriggerIndex == eventTriggerIndex) {
			return 0;
		}

		if (other.eventTriggerIndex < eventTriggerIndex) {
			return 1;
		}

		return -1;
	}
	#endregion

	public abstract void Action ();
}