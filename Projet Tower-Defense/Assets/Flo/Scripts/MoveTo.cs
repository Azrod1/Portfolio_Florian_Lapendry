using UnityEngine;
using UnityEngine.AI;

public class MoveTo : MonoBehaviour
{
    public Transform goal;
    public int damageOnBase = 1;

    void Start()
    {
        NavMeshAgent agent = GetComponent<NavMeshAgent>();
        //agent.destination = goal.position;
        agent.SetDestination(goal.position);
    }
}
