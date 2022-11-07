
using UnityEngine;

public class CubeDetector : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("phase_1");

        if (other.gameObject.CompareTag("Cube"))
        {
            Debug.Log("phase_2");

            var cubeBehaviour = other.gameObject.GetComponent<CubeBehaviour>();

            PlayerCubeManager.Instance.GetCube(cubeBehaviour);
        }
    }
}
