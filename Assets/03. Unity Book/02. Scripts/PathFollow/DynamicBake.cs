using Unity.AI.Navigation;
using UnityEngine;
using UnityEngine.AI;

public class DynamicBake : MonoBehaviour
{
    private NavMeshAgent agent;
    private NavMeshSurface surface;
    private Vector3 originPos;


    private void Start() {
        agent = GetComponent<NavMeshAgent>();
        originPos = transform.position;
    }

    private void Update() {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        var dir = new Vector3(h, 0, v);
        dir = dir.normalized;

        agent.SetDestination(dir);
        if(Vector3.Distance(transform.position, originPos) > 4f) {
            originPos = transform.position;
            surface.BuildNavMesh();
        }
    }
}
