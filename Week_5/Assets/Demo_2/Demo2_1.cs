using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Demo2_1 : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject character_1;
    public float forcePower;
    Rigidbody character_1_rigidbody;

    void Start()
    {
        character_1_rigidbody = character_1.GetComponent<Rigidbody>();
    }

    void Update()
    {
        freeMovement();
    }

    void freeMovement()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
            character_1_rigidbody.AddForce(Vector3.left * forcePower);
        if (Input.GetKey(KeyCode.RightArrow))
            character_1_rigidbody.AddForce(Vector3.right * forcePower);
        if (Input.GetKey(KeyCode.W))
            character_1_rigidbody.AddForce(Vector3.forward * forcePower);
        if (Input.GetKey(KeyCode.S))
            character_1_rigidbody.AddForce(Vector3.back * forcePower);
        if (Input.GetKey(KeyCode.UpArrow))
            character_1_rigidbody.AddForce(Vector3.up * forcePower);
        if (Input.GetKey(KeyCode.DownArrow))
            character_1_rigidbody.AddForce(Vector3.down * forcePower);

    }
}
