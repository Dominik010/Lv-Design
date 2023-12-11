using System.Collections;
using System.Collections.Generic;
using UnityEngine;

interface Interactive
{
    public void Interact();
}
public class CameraRotation : MonoBehaviour
{
    [Range (0f,10000)]
    [SerializeField] float mouseSensitivitX = 100f;
    [Range (0f,10000)]
    [SerializeField] float mouseSensitivitY = 100f;
    [SerializeField] float xRotation = 0f;

    public Transform Player;

    [Range (1f, 10f)]
    [SerializeField] float intDistance = 2f;

    bool ObjectInHand;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        CamRot();
        Interaction();
        if (transform.childCount != 0)
        {
            ObjectInHand = true;
        }
        else
        {
            ObjectInHand= false;
        }
    }

    void CamRot()
    {
        float mouseX = Input.GetAxisRaw("Mouse X") * mouseSensitivitX * Time.deltaTime;
        float mouseY = Input.GetAxisRaw("Mouse Y") * mouseSensitivitY * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        Player.Rotate(Vector3.up, mouseX);
    }

    void Interaction()
    {
        if (Input.GetKeyDown(KeyCode.E) && !ObjectInHand)
        {
            Ray interact = new Ray(transform.position, transform.forward);

            if (Physics.Raycast(interact, out RaycastHit hitInfo, intDistance))
            {
                if (hitInfo.collider.gameObject.TryGetComponent(out Interactive interactObject))
                {
                    interactObject.Interact();
                }
            }
        }
    }
}
