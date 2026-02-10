using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerI : MonoBehaviour
{

    public Vector2 moveInput;

    public bool jumpInput;

    public float sprintInput;

    public bool punchInput;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnMove(InputAction.CallbackContext ctx)
    {
        Debug.Log("is running");
        moveInput = ctx.ReadValue<Vector2>();
    }

    public void OnJump(InputAction.CallbackContext ctx)
    {
        Debug.Log("is jumping");
        jumpInput = ctx.ReadValueAsButton();
    }
    
    public void OnSprint(InputAction.CallbackContext ctx)
    {
        Debug.Log("is jumping");
        sprintInput = ctx.ReadValue<float>();
    }
    
    public void OnPunch(InputAction.CallbackContext ctx)
    {
        Debug.Log("is jumping");
        punchInput = ctx.ReadValueAsButton();
    }
}
