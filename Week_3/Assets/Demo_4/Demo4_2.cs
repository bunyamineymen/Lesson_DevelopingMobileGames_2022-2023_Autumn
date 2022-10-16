using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Demo4_2 : MonoBehaviour
{
    public GameObject duck1;
    public GameObject duck2;
    public int forceForDuck1;
    public int forceForDuck2;
    // Start is called before the first frame update
    void Start()
    {
        
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            Rigidbody duck1Rigidbody = duck1.GetComponent<Rigidbody>();
            Rigidbody duck2Rigidbody = duck2.GetComponent<Rigidbody>();
            duck1Rigidbody.AddForce(duck1.transform.up * forceForDuck1);
            duck2Rigidbody.AddForce(duck2.transform.up * forceForDuck2);
        }
    }
}
