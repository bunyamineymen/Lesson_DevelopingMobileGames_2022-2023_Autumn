using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Demo5_3 : MonoBehaviour
{

    public VirtualJoystick joystick;
    public VirtualTouchpad touchpad;

    public GameObject character;
    public float movement_power = 5f;
    Rigidbody character_rigidbody;

    // Start is called before the first frame update
    void Start()
    {
        character_rigidbody = character.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        JoystickMovement();

        if (touchpad.keyX)
            meleeAttack();
    }



    void JoystickMovement()
    {
        if(joystick.InputDir != Vector2.zero)
        {
            character_rigidbody.AddForce(character.transform.forward * movement_power * joystick.InputDir.y *-1 );
            character_rigidbody.AddForce(character.transform.right * movement_power * joystick.InputDir.x * -1);
        }
     
    }
    

    void meleeAttack()
    {
        Debug.Log("hello word");
    }



}
