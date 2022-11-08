
using UnityEngine;

public class CubeDetector : MonoBehaviour
{
    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.gameObject.CompareTag("Cube"))
    //    {
    //        var cubeBehaviour = other.gameObject.GetComponent<CubeBehaviour>();
    //        PlayerCubeManager.Instance.GetCube(cubeBehaviour);
    //    }

    //}

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Cube"))
        {
            Debug.Log("Cube");

            var cubeBehaviour = collision.gameObject.GetComponent<CubeBehaviour>();
            PlayerCubeManager.Instance.GetCube(cubeBehaviour);
        }
    }
}
