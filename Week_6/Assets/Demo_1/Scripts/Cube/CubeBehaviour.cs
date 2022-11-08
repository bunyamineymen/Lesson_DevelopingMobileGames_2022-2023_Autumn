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

    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.gameObject.CompareTag("Obstacle"))
    //    {
    //        //PlayerCubeManager.Instance.DropCube(this);

    //        transform.parent = null;
    //    }
    //}

    //private void OnCollisionEnter(Collision collision)
    //{
    //    if (collision.gameObject.CompareTag("Obstacle"))
    //    {
    //        //PlayerCubeManager.Instance.DropCube(this);

    //        transform.parent = null;
    //    }
    //}



    public void ActivatePhysics()
    {
        rgb.isKinematic = false;
    }

    private Vector3 direction = Vector3.forward;
    private bool isStack = false;
    private RaycastHit hit;



    void FixedUpdate()
    {
        float coeff = 0.02f;
        Debug.DrawRay(transform.position, direction * coeff, Color.red);

        if (Physics.Raycast(transform.position, direction, out hit, 1f * coeff))
        {
            if (!isStack)
            {
                isStack = true;
                // increase new block
                direction = Vector3.forward;

            }

            if (hit.transform.gameObject.CompareTag("Obstacle"))
            {
                //decrease block
                //PlayerCubeManager.Instance.DropCube(this);
                transform.parent = null;

            }
        }
    }



}
