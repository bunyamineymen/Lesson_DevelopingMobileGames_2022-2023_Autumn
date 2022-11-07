using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Demo5 : MonoBehaviour
{
    public GameObject bomb;
    public float bombRadius = 5.0F;
    public float bombPower = 700.0F;
    public float bombModifier = 3.0F;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            explode();
        }
    }

    void explode()
    {
        GameObject bombMuzzle = bomb.transform.GetChild(0).gameObject;
        bombMuzzle.transform.SetParent(this.gameObject.transform);
        bombMuzzle.SetActive(true);
        Vector3 explosionPos = bomb.transform.position;
        Collider[] colliders = Physics.OverlapSphere(explosionPos, bombRadius);
        foreach (Collider hit in colliders)
        {
            Rigidbody rb = hit.GetComponent<Rigidbody>();

            if (rb != null)
                rb.AddExplosionForce(bombPower, explosionPos, bombRadius, bombModifier);
        }
        bomb.SetActive(false);
    }
}
