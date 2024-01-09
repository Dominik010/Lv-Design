using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseGame : MonoBehaviour
{
    [SerializeField] private GameObject Menu;
    [SerializeField] private GameObject Crosshair;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            bool activeMenu = Menu.activeSelf;
            Pause(activeMenu);
        }      
    }

    private void Pause(bool activeMenu)
    {
        Menu.SetActive(!activeMenu);
        Crosshair.SetActive(activeMenu);
        Cursor.visible = !activeMenu;

        switch(activeMenu)
        {
            case false:
                Cursor.lockState = CursorLockMode.None;
                Time.timeScale = 0f;
                break;
            case true:
                Cursor.lockState = CursorLockMode.Locked;
                Time.timeScale = 1f;
                break;
        }
    }
}
