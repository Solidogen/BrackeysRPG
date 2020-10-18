using UnityEngine;
using UnityEngine.AI;

public class CharacterAnimator : MonoBehaviour
{
    private NavMeshAgent navMeshAgent;
    private Animator animator;
    private const float locomotionAnimationSmoothTime = 0.1f;

    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        animator = GetComponentInChildren<Animator>();
    }

    void Update()
    {
        float speedPercent = navMeshAgent.velocity.magnitude / navMeshAgent.speed;
        animator.SetFloat("SpeedPercent", speedPercent, locomotionAnimationSmoothTime, Time.deltaTime);
    }
}
