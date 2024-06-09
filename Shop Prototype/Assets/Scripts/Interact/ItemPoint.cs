using UnityEngine;
using TMPro;

//This is the script for the item tent itself, it handles how many itens it has
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

    public bool AddToChart()
    {
        if (amount <= 0) return false;
        amount--;
        if (amount < 0) amount = 0;
        countText.SetText(amount.ToString());
        return true;
    }
}
