using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    [SerializeField]
    private Transform player;
    private NavMeshAgent agent;
    [SerializeField] private Texture redTexture, pinkTexture;
    [SerializeField] private Texture attackTexture;
    [SerializeField] private Renderer ghostRedRender, ghostPinkRender;


    private Material materialRed, materialPink;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        materialRed = ghostRedRender.material;
        materialPink = ghostPinkRender.material;
    }

    private void Update()
    {
        if(player != null)
        {
            if(PlayerController.atack == false)
            {
                materialRed.SetTexture("_BaseMap", redTexture);
                materialPink.SetTexture("_BaseMap", pinkTexture);
                agent.isStopped = false;
                agent.SetDestination(new Vector3(player.position.x, player.position.y + 0.3f, player.position.z));
            }
            else
            {
                agent.isStopped = true;
                materialRed.SetTexture("_BaseMap", attackTexture);
                materialPink.SetTexture("_BaseMap", attackTexture);
            }
        }
    }
}
