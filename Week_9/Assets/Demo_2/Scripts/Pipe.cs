using System;
using UnityEngine;

public class Pipe : MonoBehaviour
{
    [SerializeField] private float startingCapacity = 100;
    [SerializeField] private float maxCapacity = 500;

    public float Capacity { get; private set; }

    private void Awake()
    {
        Capacity = startingCapacity;
    }

    public void AddFluid(float amount)
    {
        Capacity = Mathf.Clamp(amount, 0, maxCapacity);
    }
}