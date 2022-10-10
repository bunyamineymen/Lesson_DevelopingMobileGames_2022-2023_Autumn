using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Demo_4
{
    class Demo4_3 : MonoBehaviour
    {
        public GameObject ball;
        public GameObject muzzle;
        public int fireForce;

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKeyDown("space"))
            {
                muzzle.SetActive(true);
                ball.SetActive(true);
                Rigidbody ballRigidbody = ball.GetComponent<Rigidbody>();
                ballRigidbody.AddForce(ball.transform.forward * fireForce);
            }
        }
    }
}
