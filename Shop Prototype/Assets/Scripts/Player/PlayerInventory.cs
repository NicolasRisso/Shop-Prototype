using UnityEngine;

//Static class that handles all player itens
public class PlayerInventory : MonoBehaviour
{
    public struct ItemCounter
    {
        public int itemID;
        public int amount;

        public ItemCounter(int id, int amt)
        {
            itemID = id;
            amount = amt;
        }
    }

    private static PlayerInventory _instance;

    public static PlayerInventory instance
    {
        get
        {
            if (_instance == null) _instance = (Instantiate(Resources.Load("PlayerInventory")) as GameObject).GetComponent<PlayerInventory>();
            return _instance;
        }
    }

    private ItemCounter[] itemCounters;

    private void Awake()
    {
        itemCounters = new ItemCounter[8];
        for (int i = 0; i < itemCounters.Length; i++)
        {
            itemCounters[i] = new ItemCounter(i, 0);
        }
        _instance = this;
    }


    public ItemCounter[] GetItemCounters()
    {
        return itemCounters;
    }

    public void ConsumeItem(int id)
    {
        ItemCounter item = itemCounters[id];
        item.amount = 0;
        itemCounters[id] = item;
    }

    public void AddItem(int id)
    {
        ItemCounter item = itemCounters[id];
        item.amount++;
        itemCounters[id] = item;
    }

}
