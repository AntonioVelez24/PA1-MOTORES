using System;
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

    public event Action OnPlayerDamaged;
    public event Action OnPlayerDead;
    /*
    private void OnEnable()
    {
        OnPlayerDamaged +=
    }
    private void OnDisable()
    {
        OnPlayerDamaged -= 
    }
    */
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
    public void SetSpeed(float newSpeed)
    {
        speed = newSpeed;
    }
    public void SetJumpForce(float newJumpForce)
    {
        jumpForce = newJumpForce;
    }
    private void FixedUpdate()
    {
        myRigidbody.velocity = new Vector3(speed * directionX, myRigidbody.velocity.y, speed * directionZ);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            playerHealth -= 1;
            OnPlayerDamaged?.Invoke();
            if (playerHealth <= 0)
            {
                OnPlayerDead?.Invoke();
            }
        }
    }
    #region InputActions
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
    #endregion
}
