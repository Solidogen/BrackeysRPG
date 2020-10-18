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
        targetTransform?.Also(it => {
            navMeshAgent.SetDestination(it.position);
            FaceTarget();
        });
    }

    public void MoveToPoint(Vector3 point)
    {
        navMeshAgent.SetDestination(point);
    }

    public void FollowTarget(Interactable interactable)
    {
        navMeshAgent.stoppingDistance = interactable.interactionRadius * STOPPING_DISTANCE_MULTIPLIER;
        navMeshAgent.updateRotation = false;

        targetTransform = interactable.interactionTransform;
    }

    public void StopFollowingTarget()
    {
        navMeshAgent.stoppingDistance = 0f;
        navMeshAgent.updateRotation = true;

        targetTransform = null;
    }

    private void FaceTarget()
    {
        Vector3 direction = (targetTransform.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0f, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }
}
