using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class PlayerMoverRunner : MonoBehaviour
{
    private void FixedUpdate()
    {
        transform.position += new Vector3(0F, 0F, 1F) * Time.deltaTime * 5F;

        if (transform.position.x > 0.14F)
        {
            transform.position = new Vector3(0.14f, transform.position.y, transform.position.z);
        }

        if (transform.position.x < -0.14F)
        {
            transform.position = new Vector3(-0.14f, transform.position.y, transform.position.z);
        }
    }
}
