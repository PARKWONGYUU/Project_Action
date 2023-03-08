using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public Transform targetTransform;
    public Vector3 CameraOffset;

    void Update()
    {
        transform.position = targetTransform.position + CameraOffset;
    }
}
