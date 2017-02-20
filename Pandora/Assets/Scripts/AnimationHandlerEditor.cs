using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(AnimationHandler))]
public class AnimationHandlerEditor : Editor {

	override public void OnInspectorGUI(){
		AnimationHandler animHandler = (AnimationHandler)target;
		string[] animStates =  System.Enum.GetNames (typeof(AnimationHandler.AnimationState));

		GUILayout.BeginVertical ();
		{
			for (int i = 0; i < (float)animStates.Length/4f; i++) {
				GUILayout.BeginHorizontal ();
				{
					for (int j = 0; j < 4; j++) {
						if (j + i * 4 < animStates.Length) {
							if (GUILayout.Button ("Play " + animStates [j + i * 4])) {
								animHandler.UpdateAnimState ((AnimationHandler.AnimationState)System.Enum.Parse (typeof(AnimationHandler.AnimationState), animStates [j + i * 4]));
							}
						}
					}
				}
				GUILayout.EndHorizontal ();
			}
		}
		GUILayout.EndVertical ();
		DrawDefaultInspector ();
	}
}