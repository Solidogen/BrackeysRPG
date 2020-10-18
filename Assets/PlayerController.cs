using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerMotor))]
public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private LayerMask movementMask = default;

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
        if (Input.GetMouseButtonDown(0)) // LMB
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, raycastMaxDistance, movementMask))
            {
                motor.MoveToPoint(hit.point);
                // Stop focusing any objects
            }
        }
        else if (Input.GetMouseButtonDown(1)) // RMB
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, raycastMaxDistance, movementMask))
            {
                // Check if we hit an interactable and set it as a focus if so
            }
        }
    }
}
