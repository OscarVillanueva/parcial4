using System;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float smoothTime = 0.05f; 
    [SerializeField] private float gravityMultiplier = 3.0f;
    [SerializeField] private Camera cam;

    public Transform orientation;

    private CharacterController controller;

    private Vector3 movement;
    private Vector2 input;

    private float currentVelocity;
    private readonly float gravity = -9.81f;
    private float velocity;

    private void Awake()
    {
        controller = GetComponent<CharacterController>();
    }

    private void Update()
    {
        ApplyGravity();
        ApplyMovement();
    }

    private void ApplyRotation()
    {
        if (input.sqrMagnitude == 0) return;

        float targetAngle = Mathf.Atan2(movement.x, movement.z) * Mathf.Rad2Deg;
        float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref currentVelocity, smoothTime);
        transform.rotation = Quaternion.Euler(0, angle, 0);
    }

    private void ApplyMovement()
    {
        controller.Move(movement);
    }

    private void ApplyGravity()
    {
        velocity = (controller.isGrounded && velocity < 0) ? -1 : velocity + (gravity * gravityMultiplier * Time.deltaTime);
        movement.y = velocity;
    }

    public void OnMove(InputValue context)
    {
        input = context.Get<Vector2>();
        movement = speed * Time.deltaTime * new Vector3(input.x, 0, input.y).normalized;
        movement = Camera.main.transform.forward * movement.z + Camera.main.transform.right * movement.x;
    }

    public void OnInteract()
    {
        GameManager.sharedInstance.InitIniteractions();
    }

}
