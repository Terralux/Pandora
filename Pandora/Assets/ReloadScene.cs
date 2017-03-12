using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReloadScene : MonoBehaviour {

	public void TriggerReload(){
		//Debug.Log ("Reload!");
		SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex);
	}
}