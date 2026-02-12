using System;
using UnityEngine;

public class HingeEffect : MonoBehaviour
{
    [SerializeField] private float rotationForce;
    [SerializeField] private float rotationAngle;
    [SerializeField] private GameObject redKey;

    private KeyEvent _key;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _key = GetComponent<KeyEvent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_key.isGrabbed == true)
        {
            transform.Rotate(rotationForce * Vector3.up, rotationAngle);
        }
    }

    
}
