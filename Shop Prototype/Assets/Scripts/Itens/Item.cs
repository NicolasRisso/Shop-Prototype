using UnityEngine;

public class Item : MonoBehaviour
{
    public enum ClotheType
    {
        BodyClothes,
        Hair,
        Hat
    }

    [Header("Base Item Info")]
    [SerializeField] protected int ID;
    [SerializeField] protected string itemName;
    [SerializeField] protected int itemCost;
    [SerializeField] ClotheType clotheType;
    [SerializeField] protected Sprite itemIcon;
    [Header("Icon Extra Configuration")]
    [SerializeField] protected int itemIconYOffset;
    [SerializeField] protected float itemIconScale = 1;

    public int GetID()
    {
        return ID;
    }

    public string GetItemName()
    {
        return itemName;
    }

    public int GetItemCost()
    {
        return itemCost;
    }

    public ClotheType GetItemType()
    {
        return clotheType;
    }

    public Sprite GetItemIcon()
    {
        return itemIcon;
    }

    public int GetItemIconYOffset()
    {
        return itemIconYOffset;
    }

    public float GetItemIconScale()
    {
        return itemIconScale;
    }
}
