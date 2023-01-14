using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    [SerializeField] private float minViewDistance = 25;
    [SerializeField] private float mouseSensibity = 100;
    [SerializeField] private Transform playerBody;

    public Transform orientation;

    private float xRotation;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensibity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensibity * Time.deltaTime;

        xRotation = xRotation - mouseY;

        // Indicamos que xRotation no puede ser menor a 90 y mayor a minViewDistance
        xRotation = Mathf.Clamp(xRotation, -90f, minViewDistance);

        transform.localRotation = Quaternion.Euler(xRotation, 0, 0);
        orientation.localRotation = Quaternion.Euler(0, xRotation, 0);

        playerBody.Rotate(Vector3.up * mouseX);
    }
}
