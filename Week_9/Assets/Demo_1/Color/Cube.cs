using UnityEngine;

public class Cube : MonoBehaviour {

	void Start ()
	{
		GenerateColor();
	}

	public void GenerateColor ()
	{
		GetComponent<Renderer>().sharedMaterial.color = Random.ColorHSV();
	}

	public void Reset ()
	{
		GetComponent<Renderer>().sharedMaterial.color = Color.white;
	}

}
