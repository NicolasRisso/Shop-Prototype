using UnityEngine;

//Moves the NPC to the player clothe tent that he wanna buy than moves to the cashier, pays the player, and disapear.
//Did a bad habit here due to lack of time, applied the NPC Animation application here, I usually would create another class for that single handed.
public class NPC : MonoBehaviour
{
    [SerializeField] private int itemID; //ID of the item that the NPC wants to buy
    [SerializeField] private float speed;
    [SerializeField] private float arrivalDistance = 0.2f;

    private GameObject currentTarget;
    private ItemPoint itemPoint;
    private Vector3 tentPosition;
    private Vector3 cashierPosition;

    private bool isMovingToTent = true;
    private bool playerPaid = false;

    private Animator animator;
    private Rigidbody2D rb;
    private AudioSource audioSource;

    private Vector3 lastPosition;
    private Vector3 currentVelocity;

    private void Start()
    {
        lastPosition = transform.position;
        animator = GetComponentInChildren<Animator>();
        rb = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
        itemID = Random.Range(0, 8);
        FindTentAndCashier();
        MoveToTarget(tentPosition);
    }

    private void FixedUpdate()
    {
        Vector3 currentPosition = transform.position;
        currentVelocity = (currentPosition - lastPosition) / Time.fixedDeltaTime;
        lastPosition = currentPosition;

        animator.SetBool("IsMoving", (currentVelocity.magnitude >= 0.01f));
        animator.SetFloat("Horizontal", currentVelocity.x);
        animator.SetFloat("Vertical", currentVelocity.y);
        if (currentTarget != null)
        {
            MoveToTarget(currentTarget.transform.position);

            if (Vector3.Distance(transform.position, currentTarget.transform.position) <= arrivalDistance)
            {
                if (isMovingToTent)
                {
                    if (!InteractWithTent())
                    {
                        Destroy(gameObject, 1f);
                    }
                    else
                    {
                        currentTarget = GameObject.Find("Tent");
                        isMovingToTent = false;
                    }
                }
                else
                {
                    if (!playerPaid)
                    {
                        PayPlayer();
                        playerPaid = true;
                    }
                    Destroy(gameObject, 1f);
                }
            }
        }
    }

    private void FindTentAndCashier()
    {
        string tentName = "ItemPoint (" + itemID + ")";
        GameObject tent = GameObject.Find(tentName);
        if (tent != null)
        {
            tentPosition = tent.transform.position + new Vector3(0, -1, 0);
            currentTarget = tent;
            itemPoint = tent.GetComponent<ItemPoint>();
        }

        GameObject cashier = GameObject.Find("Tent");
        if (cashier != null)
        {
            cashierPosition = cashier.transform.position;
        }
    }

    private void MoveToTarget(Vector3 target)
    {
        rb.MovePosition(Vector3.MoveTowards(transform.position, target - new Vector3(0f, 1f, 0f), speed * Time.fixedDeltaTime));
    }

    private bool InteractWithTent()
    {
        bool hasProduct = itemPoint.AddToChart();
        return hasProduct;
    }

    private void PayPlayer()
    {
        audioSource.PlayOneShot(GameAssets.instance.GetBuySFX());
        PlayerMoney.instance.ReceiveGold(GameAssets.instance.GetItens()[itemID].GetItemCost() * 2);
    }
}
