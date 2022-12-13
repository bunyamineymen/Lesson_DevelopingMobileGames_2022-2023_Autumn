using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Demo1_2 : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject character_1;
    public float forcePower = 10;
    Rigidbody character_1_rigidbody;

    void Start()
    {
        character_1_rigidbody = character_1.GetComponent<Rigidbody>();
    }

    void Update()
    {
        keyboardMovement();
        jumpMovement();
    }

    void keyboardMovement()
    {

        if (Input.GetKey(KeyCode.W))
            character_1_rigidbody.AddForce(character_1.transform.forward * forcePower);
        if (Input.GetKey(KeyCode.S))
            character_1_rigidbody.AddForce(character_1.transform.forward * forcePower * -1);
        if (Input.GetKey(KeyCode.D))
            character_1_rigidbody.AddForce(character_1.transform.right * forcePower );
        if (Input.GetKey(KeyCode.A))
            character_1_rigidbody.AddForce(character_1.transform.right * forcePower * -1);
    }

    void jumpMovement()
    {
        if (Input.GetKey(KeyCode.Space))
            character_1_rigidbody.AddForce(character_1.transform.up * forcePower * 2.5f);
    }

}
