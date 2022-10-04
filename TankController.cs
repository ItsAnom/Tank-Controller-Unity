using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class TankController : MonoBehaviour
{
    private Rigidbody rb;

    [Header ("Movement Properties")]
    public float tankSpeed = 10f;
    public float tankRotationSpeed = 20f;
    private float forwardInput;
    private float rotationInput;

    void Start()
    {
        rb = GetComponent<Rigidbody>();        
    }

    private void Update()
    {
        HandleInputs();
    }

    private void FixedUpdate()
    {
        Move();
        Turn();
    }

    private void Move()
    {
        Vector3 movement = forwardInput * tankSpeed * Time.deltaTime * transform.forward;
        rb.MovePosition(rb.position + movement);
    }

    private void Turn()
    {
        float turn = rotationInput * tankRotationSpeed * Time.deltaTime;

        Quaternion turnRotation = Quaternion.Euler(0f, turn, 0f);

        rb.MoveRotation(rb.rotation * turnRotation);
    }
    private void HandleInputs()
    {
        forwardInput = Input.GetAxis("Vertical");
        rotationInput = Input.GetAxis("Horizontal");
    }
}
