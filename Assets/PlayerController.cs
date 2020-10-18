using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerMotor))]
public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private LayerMask movementMask;

    private Camera cam;
    private PlayerMotor motor;
    private float raycastMaxDistance = 100;

    void Start()
    {
        cam = Camera.main;
        motor = GetComponent<PlayerMotor>();
    }

    void Update()
    {
        // LMB
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, raycastMaxDistance, movementMask))
            {
                motor.MoveToPoint(hit.point);
                // Stop focusing any objects
            }
        }
    }
}
