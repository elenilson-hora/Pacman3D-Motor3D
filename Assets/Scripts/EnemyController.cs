using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    [SerializeField]
    private Transform player, spaw;
    private NavMeshAgent agent;
    [SerializeField]
    private Texture redTexture, pinkTexture, orangeTexture, blueTexture;
    [SerializeField] 
    private Texture attackTexture;
    [SerializeField] 
    private Renderer ghostRedRender;
    private Material materialRed;
    public int lifeGhost = 4;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        materialRed = ghostRedRender.material;
    }

    private void Update()
    {
        if(player != null)
        {
            if(PlayerController.atack == false)
            {
                if(lifeGhost == 4)
                    materialRed.SetTexture("_BaseMap", redTexture);
                if(lifeGhost == 3)
                    materialRed.SetTexture("_BaseMap", pinkTexture);
                if (lifeGhost == 2)
                    materialRed.SetTexture("_BaseMap", orangeTexture);
                if (lifeGhost == 1)
                    materialRed.SetTexture("_BaseMap", blueTexture);
                agent.SetDestination(new Vector3(player.position.x, player.position.y + 0.3f, player.position.z));
            }
            else
            {
                Vector3 direcao = transform.position - player.position;

                Vector3 destino = transform.position + direcao.normalized * 5f;

                agent.SetDestination(destino);
                materialRed.SetTexture("_BaseMap", attackTexture);
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (PlayerController.atack == true)
            {
                lifeGhost--;
                Morrer();
            }
        }
    }
    private void Morrer()
    {
        if (lifeGhost == 3)
        {
            agent.Warp(spaw.position);
            materialRed.SetTexture("_BaseMap", pinkTexture);
        }
        if (lifeGhost == 2)
        {
            agent.Warp(spaw.position);
            materialRed.SetTexture("_BaseMap", orangeTexture);
        }
        if (lifeGhost == 1)
        {
            agent.Warp(spaw.position);
            materialRed.SetTexture("_BaseMap", blueTexture);
        }
        if(lifeGhost == 0)
        {
            Destroy(gameObject);
        }

    }
}
