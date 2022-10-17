using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class GunBehaviour : MonoBehaviour
{
    public GameObject Bullet;
    public Transform BulletReference;
    public ParticleSystem ParticleSystem;

    public const float velocity = 5000;

    public void Shoot()
    {
        var bullet = Instantiate(Bullet, BulletReference.position, Quaternion.identity);
        var rgb = bullet.GetComponent<Rigidbody>();
        rgb.AddForce(BulletReference.forward * velocity, ForceMode.Force);
        ParticleSystem.Play();
    }

}
