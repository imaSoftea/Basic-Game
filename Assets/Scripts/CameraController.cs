using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target; // Public or find dynamically as before
    public Vector3 offset; // Public or set in Start
    public float moveSpeed = 5f;
    public float turnSpeed = 4f; // Speed of camera rotation
    private float pitch = 0f; // Vertical angle
    private float yaw = 0f; // Horizontal angle

    void Start()
    {
        offset = transform.position - target.position;

        Cursor.lockState = CursorLockMode.Locked;
    }

    void LateUpdate()
    {
        yaw += Input.GetAxis("Mouse X") * turnSpeed;
        pitch -= Input.GetAxis("Mouse Y") * turnSpeed;
        pitch = Mathf.Clamp(pitch, -35, 60);

        Quaternion rotation = Quaternion.Euler(pitch, yaw, 0);
        transform.position = target.position + rotation * offset; 

        Vector3 newPosition = target.position + rotation * offset;
        transform.position = Vector3.Lerp(transform.position, newPosition, moveSpeed * Time.deltaTime);
        transform.LookAt(target);
    }
}