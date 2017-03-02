using UnityEngine;
using System.Collections;

public class ParticlesManager : MonoBehaviour {

	public ParticleSystem[] particleSystems;



	// Use this for initialization
	void Start () {
		for (int i = 0; i < particleSystems.Length; i++) {
			particleSystems [i].Stop ();
		}

		StartCoroutine (NextParticleSetup ());
	}

	IEnumerator NextParticleSetup(){
		yield return new WaitForSeconds (20);

		int curIndex = Random.Range (0, particleSystems.Length);

		for (int i = 0; i < particleSystems.Length; i++) {
			if (curIndex == i) {
				particleSystems [i].Play ();
			} else {
				particleSystems [i].Stop ();
			}
		}

		StartCoroutine (NextParticleSetup ());
	}
}
