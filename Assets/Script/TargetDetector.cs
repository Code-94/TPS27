using System;
using UnityEngine;

public class TargetDetector : MonoBehaviour
{

    [SerializeField] private Vector3 boxSize;

    [SerializeField] private LayerMask layermask;
    
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public Collider[] Smashed()
    {
       return  Physics.OverlapBox(transform.position, boxSize, Quaternion.AngleAxis(0, Vector3.zero), layermask);
    }

    private void OnDrawGizmos()
    {
        if (Smashed().Length > 0)
        {
            Gizmos.color = Color.black;
            Gizmos.DrawWireCube(transform.position, boxSize);
        }
        else
        {
            Gizmos.color = Color.blue;
            Gizmos.DrawWireCube(transform.position, boxSize);
        }
    }
}
