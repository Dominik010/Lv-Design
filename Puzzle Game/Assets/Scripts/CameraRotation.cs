using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotation : MonoBehaviour
{
    [Range (0f,10000)]
    [SerializeField] float mouseSensitivity = 100f;
    [SerializeField] float xRotation = 0f;

    public Transform PlayerMesh;

    [Range (1f, 10f)]
    [SerializeField] float intDistance = 3f;
    public LayerMask Interactable;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        CamRot();
        Interaction();
    }

    void CamRot()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        PlayerMesh.Rotate(Vector3.up, mouseX);
    }

    void Interaction()
    {
        Physics.Raycast(transform.position, transform.forward, intDistance, Interactable); 
    }
}
