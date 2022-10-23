using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Demo5_2 : MonoBehaviour
{

    public VirtualJoystick joystick;
    public GameObject character_1;
    public float movement_power = 5f;
    Rigidbody character_1_rigidbody;

    // Start is called before the first frame update
    void Start()
    {
        character_1_rigidbody = character_1.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        JoystickMovement();
    }

    void JoystickMovement()
    {
        if(joystick.InputDir != Vector2.zero)
        {
            character_1_rigidbody.AddForce(character_1.transform.forward * movement_power * joystick.InputDir.y *-1 );
            character_1_rigidbody.AddForce(character_1.transform.right * movement_power * joystick.InputDir.x * -1);
        }
     
    }




}
