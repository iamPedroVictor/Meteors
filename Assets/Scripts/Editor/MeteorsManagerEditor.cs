using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(MeteorsManager))]
[CanEditMultipleObjects]
public class MeteorsManagerEditor : Editor {


	public override void OnInspectorGUI ()
	{
		base.OnInspectorGUI ();
	}

	void OnSceneGUI(){
		MeteorsManager managerMeteors = (MeteorsManager)target;

		Handles.color = Color.white;
		Handles.DrawWireArc (Vector3.zero, Vector3.forward, Vector3.up, 360f, managerMeteors.radiusSpawn);
	}

}
