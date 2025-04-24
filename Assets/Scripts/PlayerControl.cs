using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControl : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float jumpForce;
    [SerializeField] private float playerHealth;

    private Rigidbody myRigidbody;
    private float directionX;
    private float directionZ;

    private void Awake()
    {
        myRigidbody = GetComponent<Rigidbody>();
    }
    void Start()
    {
        
    }

    void Update()
    {
        
    }
    private void FixedUpdate()
    {
        myRigidbody.velocity = new Vector3(speed * directionX, myRigidbody.velocity.y, speed * directionZ);
    }
    public void OnMovementX (InputAction.CallbackContext context)
    {
        directionX = context.ReadValue<float>();
    }
    public void OnMovementZ(InputAction.CallbackContext context)
    {
        directionZ = context.ReadValue<float>();
    }
    public void OnJumpInput(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            myRigidbody.AddForce(myRigidbody.transform.up * jumpForce, ForceMode.Impulse);
        }
    }
}
