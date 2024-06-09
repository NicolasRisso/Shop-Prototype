using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class PlayerBuy : MonoBehaviour, IShopCustomer
{
    private AudioSource audioSource;

    //Doesn't need try catch because audio source is required for this component
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void BoughtItem(Item item)
    {
        audioSource.PlayOneShot(GameAssets.instance.GetBuySFX());
        Debug.Log("Buyed: " + item.GetItemName());
    }

    public bool TrySpendGoldAmount(int spendGoldAmount)
    {
        return PlayerMoney.instance.SpendGold(spendGoldAmount);
    }
}
