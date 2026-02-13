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
            Debug.Log("respawn to : " + spawnZone.transform.position);
            if (other.TryGetComponent(out CharacterController ch))
            {
                ch.enabled = false;
                other.transform.position = spawnZone.transform.position;
                ch.enabled = true;
            }
        }
    }
}
