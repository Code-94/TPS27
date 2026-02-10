using System;
using UnityEngine;

public class Detector : MonoBehaviour
{
    [SerializeField] private float radius;

    [SerializeField] private LayerMask _layerMask;

    public bool isTouching;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        isTouching = Physics.CheckSphere(transform.position, radius, _layerMask);
    }

    private void OnDrawGizmos()
    {
        if (isTouching)
        {
            Gizmos.color = Color.green;
            Gizmos.DrawWireSphere(transform.position, radius);
        }
        else
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, radius);
        }
    }
}
