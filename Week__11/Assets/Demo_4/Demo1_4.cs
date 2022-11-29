using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Demo1_4 : MonoBehaviour
{

    public Camera[] camera_list;

    int camera_id = 0;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        cameraController();
    }

    void cameraController()
    {
        if(Input.GetMouseButtonDown(0))
        {
            changeCamera();
        }
    }

    void changeCamera()
    {
        camera_id++;
        int index = camera_id % camera_list.Length;
        for(int i = 0; i< camera_list.Length; i++)
            camera_list[i].gameObject.SetActive(false);

        camera_list[index].gameObject.SetActive(true);
    }

}
