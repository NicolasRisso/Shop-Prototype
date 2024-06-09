using UnityEngine;
using UnityEngine.AI;

public class NPC : MonoBehaviour
{
    [SerializeField] private int itemID; //ID of the item that the NPC wants to buy

    private NavMeshAgent agent;
    private GameObject currentTarget;
    private Vector3 tentPosition;
    private Vector3 cashierPosition;

    void Start()
    {
        itemID = Random.Range(0, 8);
        agent = GetComponent<NavMeshAgent>();
        FindTentAndCashier();
        MoveToTarget(tentPosition);
    }

    void Update()
    {
        if (!agent.pathPending && agent.remainingDistance <= agent.stoppingDistance)
        {
            if (currentTarget.CompareTag("Tent"))
            {
                InteractWithTent();
                MoveToTarget(cashierPosition);
            }
            else if (currentTarget.CompareTag("Cashier"))
            {
                PayPlayer();
                Destroy(gameObject);
            }
        }
    }

    void FindTentAndCashier()
    {
        // Localiza a tenda usando o nome
        string tentName = "ItemPoint (" + itemID + ")";
        GameObject tent = GameObject.Find(tentName);
        if (tent != null)
        {
            tentPosition = tent.transform.position + new Vector3(0, -1, 0); // Posição na frente da tenda
            currentTarget = tent;
        }

        // Localiza o caixa
        GameObject cashier = GameObject.Find("Tent");
        if (cashier != null)
        {
            cashierPosition = cashier.transform.position; // Posição do caixa
        }
    }

    void MoveToTarget(Vector3 position)
    {
        agent.SetDestination(position);
    }

    void InteractWithTent()
    {
        Debug.Log("Itens subtraídos da tenda.");
    }

    void PayPlayer()
    {
        Debug.Log("Pagamento realizado ao player.");
    }
}
