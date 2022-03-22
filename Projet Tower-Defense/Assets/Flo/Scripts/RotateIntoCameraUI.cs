using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateIntoCameraUI : MonoBehaviour
{
    void Update()
    {
        transform.rotation = MoveCamera.instance.GetComponentInChildren<Camera>().transform.rotation;
    }
}
