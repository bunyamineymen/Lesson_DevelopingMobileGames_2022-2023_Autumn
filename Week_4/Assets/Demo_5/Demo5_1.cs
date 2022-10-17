using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Demo5_1 : MonoBehaviour
{   

    public GameObject duckBody;
    public GameObject laserMachine;
    public int RotationSpeed = 5;
    public int laserLength = 15;

    public Material redMaterial;
    public Material defaultMaterial;

    Ray ray;
    RaycastHit hit;

   
    // Start is called before the first frame update
    void Start()
    {

     

    }


    // Update is called once per frame
    void FixedUpdate()
    {

        float mouseAxis = Input.GetAxis("Mouse X");
        rotateLaserMachine(mouseAxis);
        duckBody.GetComponent<MeshRenderer>().material = defaultMaterial;
        handleRaycast(laserMachine);
    }

    void rotateLaserMachine(float axis)
    {
        laserMachine.transform.Rotate(
            0, 
            (axis * RotationSpeed ), 
            0, 
            Space.World
       );
    }

    void handleRaycast(GameObject handler)
    {
        // Does the ray intersect any objects excluding the player layer
        Debug.DrawRay(handler.transform.position, handler.transform.TransformDirection(Vector3.forward) * 15, Color.red);
        if (Physics.Raycast(handler.transform.position, laserMachine.transform.TransformDirection(Vector3.forward), out hit, laserLength))
        {
            if(hit.transform.gameObject.name == "Duck")
            {
                duckBody.GetComponent<MeshRenderer>().material = redMaterial;
                Debug.Log("We hit the duck !");
            }
            
        }
    }
}

