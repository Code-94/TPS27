using UnityEngine;
using Quaternion = UnityEngine.Quaternion;
using Vector3 = UnityEngine.Vector3;

public class PlayerController : MonoBehaviour
{

    [SerializeField] private float moveSpeed;
    [SerializeField] private float sprintForce;
    [SerializeField] private float jumpForce;
    [SerializeField] private Detector groundDetector;
    [SerializeField] private float fallFactor;
    [SerializeField] private float jumpHeight;
    [SerializeField] private float punchForce;
    [SerializeField] private TargetDetector target1;

    private PlayerI _input;
    private Animator _animator;
    private CharacterController _controller;
    private float _horizontalVelocity;
    private Vector3 _verticalVelocity;
    
    
    

    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _input = GetComponent<PlayerI>();
        _controller = GetComponent<CharacterController>();
        _animator = GetComponent<Animator>();
        

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 Hmove = (moveSpeed * _input.moveInput.magnitude * Time.deltaTime) * transform.forward;
        

        if (groundDetector.isTouching)
        {
            _verticalVelocity = Physics.gravity * (fallFactor * Time.deltaTime);
            _animator.SetBool("OnLand", true);
            

            if (_input.jumpInput)
            {
                _verticalVelocity = Vector3.up * Mathf.Sqrt(jumpHeight * -2f * Physics.gravity.y);
                _animator.SetBool("OnJump", true);
            }
            else
            {
                _animator.SetBool("OnJump", false);
                
            }
            
            
            if (_input.sprintInput >= 0.1f && _input.moveInput.magnitude > 0f)
            {
                Hmove = (moveSpeed * _input.moveInput.magnitude * sprintForce * Time.deltaTime) * transform.forward;
                _animator.SetFloat("OnSprint", _input.sprintInput);
            }
            else
            {
                _input.sprintInput = 0f;
                _animator.SetFloat("OnSprint", _input.sprintInput);
            }
            
            
            if (_input.punchInput)
            {
                _animator.SetBool("OnPunch", true);
                _animator.SetBool("Punching", true);
                var smashedObj = target1.Smashed();
            
                foreach (Collider collect in smashedObj)
                {
                    collect.transform.position =  punchForce * Vector3.up;
                }
            }
            else
            {
                _animator.SetBool("OnPunch", false);
            }

            
             if (_controller.velocity.y > 0)
             {
                 _verticalVelocity += Physics.gravity * Time.deltaTime;
             }
             else
             {
                 _verticalVelocity += Physics.gravity * (fallFactor * Time.deltaTime);
                 
             }
        }
        else
        {
            _verticalVelocity += Physics.gravity * Time.deltaTime;
        }
        
        _controller.Move(Hmove);

        

        if (_input.moveInput.magnitude < 0.1)
        {
            _animator.SetFloat("OnMove", _input.moveInput.magnitude);
            
        }
        if (_input.moveInput.magnitude >= 0.20)
        {
            
            _animator.SetFloat("OnMove", _input.moveInput.magnitude);
        }

        

        

        Quaternion InputRotation = Quaternion.LookRotation(new Vector3(_input.moveInput.x, 0, _input.moveInput.y), Vector3.up);
        Quaternion cameraRotation = Camera.main.transform.rotation;
        Quaternion rotation = Quaternion.Euler(0, cameraRotation.eulerAngles.y, 0) * InputRotation;

        _controller.Move(Hmove * Time.deltaTime + _verticalVelocity * Time.deltaTime);
        if (Hmove.sqrMagnitude > 0.001f)
        {
            transform.rotation = rotation;
        }

    }
    
}
