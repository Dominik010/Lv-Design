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

    private Light cLight;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        cLight = GetComponent<Light>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Interaction();
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            LightSwitch();
        }
        if (transform.childCount != 0)
        {
            ObjectInHand = true;
        }
        else
        {
            ObjectInHand = false;
        }
    }

    private void FixedUpdate()
    {
        CamRot();
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
        if (!ObjectInHand)
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

        else if (ObjectInHand && transform.GetChild(0).gameObject.activeSelf == false)
        {
           transform.DetachChildren();
        }
    }

    private void LightSwitch()
    {
        cLight.enabled = !cLight.enabled;
    }
}
