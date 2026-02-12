using System;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    [SerializeField] private Transform spawnZone;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.transform.position = spawnZone.position;
        }
    }
}
