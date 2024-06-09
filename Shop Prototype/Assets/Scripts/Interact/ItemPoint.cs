using UnityEngine;
using TMPro;

public class ItemPoint : MonoBehaviour, Interaction
{
    [SerializeField] private int itemID;
    private int amount = 0;

    private TextMeshPro countText;

    private void Start()
    {
        try
        {
            countText = GetComponentInChildren<TextMeshPro>();
            if (countText == null) throw new System.Exception("ItemPoint could not locate TextMeshPro");
        }
        catch(System.Exception e)
        {
            Debug.LogException(e);
        }
    }

    public void Interact(IShopCustomer shopCustomer)
    {
        amount += PlayerInventory.instance.GetItemCounters()[itemID].amount;
        PlayerInventory.instance.ConsumeItem(itemID);
        countText.SetText(amount.ToString());
    }
}
