using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Demo1_5 : MonoBehaviour
{
    // Start is called before the first frame update
    public Camera main_camera;

    public float movement_speed = 10f;
    public float rotation_speed = 2.5f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        mouse_movement();
        keyboard_movement();
    }

    void mouse_movement()
    {
        float mouseAxisX = Input.GetAxis("Mouse X");
        float mouseAxisY = Input.GetAxis("Mouse Y");
        main_camera.transform.Rotate(
            (mouseAxisY * rotation_speed *-1),
            (mouseAxisX * rotation_speed ),
            0,
            Space.World
       );
        float z = main_camera.transform.eulerAngles.z;
        main_camera.transform.Rotate(0, 0, -z);

    }
   
    void keyboard_movement()
    {
        Vector3 camera_pos = main_camera.transform.position;
        if(Input.GetKey(KeyCode.W))
            camera_pos += main_camera.transform.forward  + new Vector3(movement_speed * Time.deltaTime, 0, 0);
        if (Input.GetKey(KeyCode.S))
            camera_pos += main_camera.transform.forward *-1 + new Vector3(movement_speed * Time.deltaTime * -1, 0, 0);
        if (Input.GetKey(KeyCode.A))
            camera_pos += main_camera.transform.right *-1 + new Vector3(0, movement_speed * Time.deltaTime *-1, 0);
        if (Input.GetKey(KeyCode.D))
            camera_pos += main_camera.transform.right + new Vector3(0, movement_speed * Time.deltaTime, 0);
        main_camera.transform.position = camera_pos;
    }
}
