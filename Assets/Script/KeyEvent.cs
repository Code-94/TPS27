using System;
using UnityEngine;

public class KeyEvent : MonoBehaviour
{

    [SerializeField] private float radius;

    [SerializeField] private LayerMask playerMask;
    [SerializeField] private float RotationForce;
    [SerializeField] private float rotateAngle;

    public bool isGrabbed;

    private Collider[] _tab0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        transform.Rotate(RotationForce * Vector3.up, rotateAngle);
        int smash = Physics.OverlapSphereNonAlloc(transform.position, radius, _tab0, playerMask);

        if (smash > 0)
        {
            isGrabbed = true;
        }
    }

    private void OnDrawGizmos()
    {
        if (!isGrabbed)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position,radius);
        }
        else
        {
            Gizmos.color = Color.green;
            Gizmos.DrawWireSphere(transform.position,radius);
        }
        
    }
}
