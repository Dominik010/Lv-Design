using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine.SceneManagement;
using UnityEngine;

public class ButtonPlay : MonoBehaviour
{
    public void OnClick()
    {
        SceneManager.LoadScene("Level");
    }
}
