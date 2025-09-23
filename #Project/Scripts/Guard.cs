using UnityEngine;
using UnityEngine.AI;

public class Guard : MonoBehaviour
{
    public enum GuardState
    {
        Patrol,
        Chase,
    }

    private GuardState state;

    [SerializeField] Transform wayPoints;
    NavMeshAgent agent;

    [Header("Vision")]
    [SerializeField] float maxDistance;
    [SerializeField] float maxAngle;
    [SerializeField] Transform playerTranform;

    void ChooseNewDestination()
    {
        int index = Random.Range(0, wayPoints.childCount); // choisir un point random
        Transform dest = wayPoints.GetChild(index); // on choisit dans la liste de destination possible
        agent.SetDestination(dest.position); // l'agent prend la position du player
    }
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        state = GuardState.Patrol; // au debut on veut juste patrouiller

        ChooseNewDestination();
    }

    void Update()
    {

        switch (state)
        {
            case GuardState.Patrol:
                if (Vector3.Distance(agent.destination, transform.position) <= 0.5f)
                {
                    ChooseNewDestination(); // si il arrive à la destionation, en choisit une autre
                }
                
                if (CanWeSeeThePlayer())
                {
                    state = GuardState.Chase; // si on voit le joueur, on le poursuit
                }

                if (!CanWeSeeThePlayer())
                {
                    state = GuardState.Patrol; // si il ne le voit pas, il continu son chemin
                }

                break;

            case GuardState.Chase:
                agent.SetDestination(playerTranform.position); // l'agent prend la position du player
                break;
        }
    }

    bool CanWeSeeThePlayer()
    {
        RaycastHit hit;
        Vector3 playerDirection = playerTranform.position - transform.position;

        if (Physics.Raycast(transform.position + Vector3.up * 0.3f, playerDirection, out hit, maxDistance)) // out = c'est quelque chose que je donne vide et que j'attends que unity le remplisse avec de bonnes infos
        {
            // Debug.Log($"we hit the {hit.collider.name}");
            if (hit.collider.CompareTag("Player"))
            {
                if (Vector3.Angle(transform.forward, playerDirection) <= maxAngle)
                {
                    return true;
                }
            }
        }
        return false; 
    }
}