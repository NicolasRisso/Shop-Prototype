public interface IShopCustomer
{
    void BoughtItem(Item item);
    bool TrySpendGoldAmount(int goldAmount);
}
