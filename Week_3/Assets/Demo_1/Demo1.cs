
using UnityEngine;

public class Demo1 : MonoBehaviour
{

    public GameObject gameobject;
    public int mass = 5;

    private void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            if (!gameobject.GetComponent<Rigidbody>())
            {
                Rigidbody newRigidbody = gameobject.AddComponent<Rigidbody>();
                newRigidbody.mass = mass;
            }
         
           
        }
    }

}
