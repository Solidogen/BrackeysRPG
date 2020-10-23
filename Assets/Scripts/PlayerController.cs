using UnityEngine;
using UnityEngine.EventSystems;

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
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }

        // TODO extract those to a function
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
                interactable?.Also(it =>
                {
                    SetFocus(it);
                });
            }
        }
    }

    private void SetFocus(Interactable interactable)
    {
        if (focusedInteractable != interactable)
        {
            focusedInteractable?.onDefocused();
            focusedInteractable = interactable;
            playerMotor.FollowTarget(interactable);
        }
        focusedInteractable.OnFocused(playerTransform: transform);
    }

    private void RemoveFocus()
    {
        focusedInteractable?.onDefocused();
        focusedInteractable = null;
        playerMotor.StopFollowingTarget();
    }
}
