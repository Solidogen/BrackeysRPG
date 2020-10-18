using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class PlayerMotor : MonoBehaviour
{
    private NavMeshAgent navMeshAgent;
    private Transform targetTransform;
    private const float STOPPING_DISTANCE_MULTIPLIER = 0.8f;

    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        // TODO use coroutine instead
        if (targetTransform != null)
        {
            navMeshAgent.SetDestination(targetTransform.position);
        }
    }

    public void MoveToPoint(Vector3 point)
    {
        navMeshAgent.SetDestination(point);
    }

    public void FollowTarget(Interactable interactable)
    {
        navMeshAgent.stoppingDistance = interactable.radius * STOPPING_DISTANCE_MULTIPLIER;
        targetTransform = interactable.transform;
    }

    public void StopFollowingTarget()
    {
        navMeshAgent.stoppingDistance = 0f;
        targetTransform = null;
    }
}
