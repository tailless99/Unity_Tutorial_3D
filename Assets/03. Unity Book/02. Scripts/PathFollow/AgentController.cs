using UnityEngine;
using UnityEngine.AI;

public class AgentController : MonoBehaviour
{
    public Transform player;
    private NavMeshAgent agent; // 네브메시 에이전트

    public Transform[] points;
    public int index;

    private void Start() {
        //player = GameObject.Find("Player").transform;
        agent = GetComponent<NavMeshAgent>();
        SetRandomPoint();
    }

    private void Update() {
        //agent.SetDestination(points[index].transform.position);
        if (agent.remainingDistance <= 1.5f) {
            Debug.Log("목적지 변경");
            SetRandomPoint();
        }
    }

    private void SetRandomPoint() {
        int temp = index;
        while(temp == index)
            index = Random.Range(0, points.Length);
        agent.SetDestination(points[index].transform.position);
    }
}
