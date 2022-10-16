using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Demo3 : MonoBehaviour
{
    public GameObject gameobject;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            Rigidbody rigidbody = gameobject.GetComponent<Rigidbody>();
            rigidbody.useGravity = !rigidbody.useGravity;
        }
    }
}
