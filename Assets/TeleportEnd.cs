using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TeleportEnd : MonoBehaviour
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
            
            if (other.TryGetComponent(out CharacterController ch))
            {
                other.gameObject.SetActive(false);
                ch.enabled = false;
                other.transform.position = spawnZone.transform.position;
                SceneManager.LoadSceneAsync(2);
                ch.enabled = true;
            }
            
        }
    }
}
