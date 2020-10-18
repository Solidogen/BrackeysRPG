using UnityEngine;

public class Interactable : MonoBehaviour
{
    private bool isFocusedByPlayer = false;
    private Transform playerTransform;
    private bool hasInteracted = false;

    public Transform interactionTransform;
    public float interactionRadius = 3f;

    void Update()
    {
        if (isFocusedByPlayer && !hasInteracted)
        {
            float distanceFromPlayer = Vector3.Distance(playerTransform.position, interactionTransform.position);
            if (distanceFromPlayer <= interactionRadius)
            {
                Interact();
                hasInteracted = true;
            }
        }
    }

    public virtual void Interact()
    {
        Debug.Log("Interacting with: " + transform.name);
    }

    public void OnFocused(Transform playerTransform)
    {
        isFocusedByPlayer = true;
        this.playerTransform = playerTransform;
        hasInteracted = false;
    }

    public void onDefocused()
    {
        isFocusedByPlayer = false;
        playerTransform = null;
        hasInteracted = false;
    }

    void OnDrawGizmosSelected()
    {
        if (interactionTransform == null)
        {
            interactionTransform = transform;
        }
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(interactionTransform.position, interactionRadius);
    }
}
