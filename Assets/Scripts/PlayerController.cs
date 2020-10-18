using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerMotor))]
public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private LayerMask movementMask = default;

    [SerializeField]
    private Interactable focusedInteractable = default;

    private Camera cam;
    private PlayerMotor playerMotor;
    private float raycastMaxDistance = 100;

    void Start()
    {
        cam = Camera.main;
        playerMotor = GetComponent<PlayerMotor>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // LMB
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, raycastMaxDistance, movementMask))
            {
                playerMotor.MoveToPoint(hit.point);
                RemoveFocus();
            }
        }
        else if (Input.GetMouseButtonDown(1)) // RMB
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, raycastMaxDistance, movementMask))
            {
                Interactable interactable = hit.collider.GetComponent<Interactable>();
                if (interactable != null)
                {
                    SetFocus(interactable);
                }
            }
        }
    }

    private void SetFocus(Interactable interactable)
    {
        focusedInteractable = interactable;
        playerMotor.FollowTarget(interactable);
    }

    private void RemoveFocus()
    {
        focusedInteractable = null;
        playerMotor.StopFollowingTarget();
    }
}
