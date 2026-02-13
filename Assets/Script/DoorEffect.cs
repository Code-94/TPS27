using UnityEngine;

public class DoorEffect : MonoBehaviour
{
    [SerializeField] private KeyEvent _key;

    private Animator _animator;
    public bool isOpen;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_key.isGrabbed)
        {
            isOpen = true;
            
            
        }

        if (isOpen)
        {
            _animator.SetTrigger("StillOpen");
            
            _animator.SetTrigger("KeepOpen");
        }
    }
}
