using UnityEngine;
using UnityEngine.AI;

public class BossController : MonoBehaviour
{
    private NavMeshAgent agent;
    public Transform target;

    void Update() {
        agent.SetDestination(target.position);
    }
}
