using UnityEngine;

//Class to connect player buying itens with the UI
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
        PlayerInventory.instance.AddItem(item.GetID());
    }

    public bool TrySpendGoldAmount(int spendGoldAmount)
    {
        return PlayerMoney.instance.SpendGold(spendGoldAmount);
    }
}
