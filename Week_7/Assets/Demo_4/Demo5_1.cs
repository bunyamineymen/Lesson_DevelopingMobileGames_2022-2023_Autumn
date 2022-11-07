using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Demo5_1 : MonoBehaviour
{
    public GameObject actor;
    public float movementSpeed = 20f;

    // Start is called before the first frame update
    void Start()
    {
  
    }

    void FixedUpdate()
    {

        float mouseAxis = Input.GetAxis("Mouse X");
        moveActor(mouseAxis);
    }
    void moveActor(float axis)
    {
        float calculation = actor.transform.position.x +  axis * movementSpeed * Time.deltaTime;
        if (calculation < -4 || calculation > 4)
        {
            calculation = actor.transform.position.x;
        }
        actor.transform.position = new Vector3(calculation, actor.transform.position.y, actor.transform.position.z);
    }

}
