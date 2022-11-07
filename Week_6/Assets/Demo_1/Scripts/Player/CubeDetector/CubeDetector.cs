
using UnityEngine;

public class CubeDetector : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Cube"))
        {
            var cubeBehaviour = other.gameObject.GetComponent<CubeBehaviour>();
            PlayerCubeManager.Instance.GetCube(cubeBehaviour);
        }

    }
}
