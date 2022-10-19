
using UnityEngine;

public class Demo2Run : MonoBehaviour
{
    public Transform tr;
    public Rigidbody rgb;

    private void Start()
    {
    }

    private void Update()
    {
        Slide(tr, Vector3.right);
    }

    void Slide(Transform target, Vector3 railDirection)
    {
        Vector3 heading = target.position - transform.position;
        Vector3 force = Vector3.Project(heading, railDirection);

        rgb.AddForce(force);
    }

}
