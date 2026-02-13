using UnityEngine;

public class DoorEffect : MonoBehaviour
{
    [SerializeField] private KeyEvent _key1;
    [SerializeField] private KeyEvent _key2;
    
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
        if (_key1.isGrabbed || _key2.isGrabbed)
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
