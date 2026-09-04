using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    [SerializeField]
    private Transform player;
    private NavMeshAgent agent;
    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        if(player != null)
        {
            agent.SetDestination(new Vector3(player.position.x, player.position.y + 0.3f, player.position.z));
        }
    }
}
