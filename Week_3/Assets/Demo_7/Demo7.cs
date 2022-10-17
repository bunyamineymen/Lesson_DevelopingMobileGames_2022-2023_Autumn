
using UnityEngine;

public class Demo7 : MonoBehaviour
{

    public GunBehaviour GunBehaviour;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GunBehaviour.Shoot();
        }
    }
}
