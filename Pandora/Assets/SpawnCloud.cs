using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCloud : BaseEvent {

	public GameObject cloudParticles;

	private GameObject go; 
	private Transform target;

	public GameObject building;
	public Vector3 targetPosition;

	void Awake(){
		Toolbox.RegisterEvent <SpawnCloud>(this);
		target = GameObject.FindGameObjectWithTag ("CloudSpawnTarget").transform;
	}

	#region implemented abstract members of BaseEvent

	public override void Action ()
	{
		go = Instantiate (cloudParticles, target.position, cloudParticles.transform.rotation);
		go.transform.SetParent (target);

		StartCoroutine (WaitForClouds ());
	}

	#endregion

	IEnumerator WaitForClouds(){
		yield return new WaitForSeconds (12f);
		go.transform.SetParent (null);

		GameObject buildingGO = Instantiate (building, targetPosition + go.transform.position, building.transform.rotation);
		yield return new WaitForSeconds (0.01f);
		Toolbox.FindRequiredComponent<EventSystem> ().PlayNextEvent ();

		Destroy (gameObject);
	}
}