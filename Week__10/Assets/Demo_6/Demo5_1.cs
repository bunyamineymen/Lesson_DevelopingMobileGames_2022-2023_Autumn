using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Demo5_1 : MonoBehaviour
{

    public VirtualTouchpad touchpad;
    public GameObject character_1;
    public GameObject duck_ass;
    public Material egg_material;
    public float egg_spawn_power = 800;


    public float movement_power = 10;
    public float Rotation_speed = 5;
    Rigidbody character_1_rigidbody;

    // Start is called before the first frame update
    void Start()
    {
        character_1_rigidbody = character_1.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        jumpMovement();

        EggControl();
    }

  
    void jumpMovement()
    {
        if (touchpad.keyA)
            character_1_rigidbody.AddForce(character_1.transform.up * movement_power * 2.5f);
    }

    void EggControl()
    {
        if (touchpad.keyY)
            createEgg();
    }


    void createEgg()
    {
        GameObject egg = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        egg.name = "An egg";
        egg.AddComponent<SphereCollider>();
        egg.AddComponent<Rigidbody>();
        egg.AddComponent<MeshRenderer>();
        egg.GetComponent<MeshRenderer>().material = egg_material;

        Vector3 egg_throw_position = duck_ass.transform.position;
        egg.transform.position = egg_throw_position;
        egg.GetComponent<Rigidbody>().mass = 1;
        egg.GetComponent<Rigidbody>().AddForce(egg.transform.forward * egg_spawn_power * -1);
    }
}
