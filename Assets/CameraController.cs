using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    private Transform target = default;

    [SerializeField]
    private Vector3 offset = default;

    [SerializeField]
    private float pitch = 2f;

    [SerializeField]
    private float currentZoom = 10f;

    void LateUpdate()
    {
        transform.position = target.position - offset * currentZoom;
        transform.LookAt(target.position + Vector3.up * pitch);
    }
}
