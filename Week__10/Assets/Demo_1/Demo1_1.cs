using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Demo1_1 : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject cube;
    public float forcePower = 50;
    public float rotatePower= 100;
    public float jumpPower = 20;


    public Material[] materialList;

    private Rigidbody cube_rigidbody;
    private int rightClickCounter;
    void Start()
    {
        cube_rigidbody = cube.GetComponent<Rigidbody>();
    }

    void Update()
    {
        axisMovement();
        wheelMovement();
        clickMovement();
    }

    void axisMovement()
    {
        float X = Input.GetAxis("Mouse X");
        float Y = Input.GetAxis("Mouse Y");
        cube_rigidbody.AddForce(Vector3.left * forcePower * X * -1);
        cube_rigidbody.AddForce(Vector3.forward * forcePower* Y);
    }


    void wheelMovement()
    {
        float scroll = Input.mouseScrollDelta.y;
        cube.transform.Rotate(new Vector3(0, rotatePower, 0) * scroll);
    }

    void clickMovement()
    {
        if (Input.GetMouseButton(0))    //While MS each pressed
            cube_rigidbody.AddForce(Vector3.up * jumpPower);
        if (Input.GetMouseButtonDown(1)) //While once pressed
            this.changeMaterial();
            
    }

    private void changeMaterial()
    {
        rightClickCounter++;
        int index = rightClickCounter % materialList.Length;
        cube.GetComponent<MeshRenderer>().material = materialList[index];
    }

   
}
