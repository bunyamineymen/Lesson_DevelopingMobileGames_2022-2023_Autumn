using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Sphere))]
public class SphereEditor : Editor {

	public override void OnInspectorGUI()
	{
		Sphere sphere = (Sphere)target;

		GUILayout.Label("Oscillates around a base size.");

		sphere.baseSize = EditorGUILayout.Slider("Size", sphere.baseSize, .1f, 2f);

		sphere.transform.localScale = Vector3.one * sphere.baseSize;
	}

}
