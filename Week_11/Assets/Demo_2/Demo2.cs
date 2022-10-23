using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Demo2 : MonoBehaviour
{
    public Animator animatorController;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        jumpControl();
    }

    void jumpControl()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            animatorController.SetTrigger("jump");


    }
}
