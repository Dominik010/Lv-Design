using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonScaler : MonoBehaviour
{
    private Vector3 oSize;

    private void Awake()
    {
        oSize = transform.localScale;
    }

    void ScaleDown()
    {
        transform.localScale = oSize;
    }
}
