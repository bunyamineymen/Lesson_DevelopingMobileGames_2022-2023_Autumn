using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class Demo1_3 : MonoBehaviour
{
    public GameObject character_1;
    public GameObject duck_ass;
    public Camera main_camera;
    public Material egg_material;
    public float egg_spawn_power = 800;
    public float movement_power = 10;
    public float Rotation_speed = 5;
    public float wheel_factor = 0.5f;
    Rigidbody character_1_rigidbody;

    // Start is called before the first frame update
    void Start()
    {
        character_1_rigidbody = character_1.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        keyboardMovement();
        jumpMovement();
        EggControl();
        mouseMovement();
        wheelMovement();
    }



    void keyboardMovement()
    {

        if (Input.GetKey(KeyCode.W))
            character_1_rigidbody.AddForce(character_1.transform.forward * movement_power);
        if (Input.GetKey(KeyCode.S))
            character_1_rigidbody.AddForce(character_1.transform.forward * movement_power * -1);
        if (Input.GetKey(KeyCode.D))
            character_1_rigidbody.AddForce(character_1.transform.right * movement_power);
        if (Input.GetKey(KeyCode.A))
            character_1_rigidbody.AddForce(character_1.transform.right * movement_power * -1);
    }

    void jumpMovement()
    {
        if (Input.GetKey(KeyCode.Space))
            character_1_rigidbody.AddForce(character_1.transform.up * movement_power * 0.95f);
    }

    void EggControl()
    {
        if (Input.GetMouseButtonDown(0))
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

    void mouseMovement()
    {
        float mouseAxis = Input.GetAxis("Mouse X");
        character_1.transform.Rotate(
            0,
            (mouseAxis * Rotation_speed),
            0,
            Space.World
       );
    }

    void wheelMovement()
    {
        Vector3 camera_position = main_camera.transform.position;
        camera_position.y += Input.mouseScrollDelta.y * wheel_factor * -1;
        main_camera.transform.position = camera_position;
    }
}
