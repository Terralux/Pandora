using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HackFixTheFuckOutOfTheLogo : MonoBehaviour {

	public void ActivateMeshRenderer(){
		GetComponentInChildren<MeshRenderer> ().enabled = true;
	}
	public void ActivateSkinnedMeshRenderer(){
		GetComponentInChildren<MeshRenderer> ().enabled = false;
		GetComponentInChildren<SkinnedMeshRenderer> ().enabled = true;
	}
}