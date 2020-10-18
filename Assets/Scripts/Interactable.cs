using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    private bool isFocusedByPlayer = false;
    private Transform playerTransform;

    public float interactionRadius = 3f;

    void Update()
    {
        if (isFocusedByPlayer)
        {
            float distanceFromPlayer = Vector3.Distance(playerTransform.position, transform.position);
            if (distanceFromPlayer <= interactionRadius)
            {
                Debug.Log("Interaction");
            }
        }
    }

    public void OnFocused(Transform playerTransform)
    {
        isFocusedByPlayer = true;
        this.playerTransform = playerTransform;
    }

    public void onDefocused()
    {
        isFocusedByPlayer = false;
        playerTransform = null;
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, interactionRadius);
    }
}
