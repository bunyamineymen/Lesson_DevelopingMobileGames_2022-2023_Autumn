using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class CubeBehaviour : MonoBehaviour
{

    #region Variable: Rigidbody

    [SerializeField]
    private Rigidbody rgb;
    public Rigidbody Rgb { get => rgb; set => rgb = value; }

    #endregion


    #region Variable: IndexOfCube

    private int indexOfCube = -1;

    public int IndexOfCube { get => indexOfCube; set => indexOfCube = value; }

    #endregion

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Obstacle"))
        {
            PlayerCubeManager.Instance.DropCube(this);
        }
    }

    public void ActivatePhysics()
    {
        rgb.isKinematic = false;
    }
}
