using UnityEngine;

//Calls the Shop UI when interacted with
public class ShopSpot : MonoBehaviour, Interaction
{
    [SerializeField] private string GO_Name = "UI_Shop";

    private BaseShop ui_shop;

    private bool isShopUIShowing = false;

    private void Start()
    {
        try
        {
            ui_shop = GameObject.Find(GO_Name).GetComponent<BaseShop>();
            if (ui_shop == null) throw new System.Exception("ShopSpot could not locate UI_Shop in the scene");
        }
        catch(System.Exception e)
        {
            Debug.LogException(e);
        }
        
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            ui_shop.Hide();
            isShopUIShowing = false;
        }
    }

    public void Interact(IShopCustomer shopCustomer)
    {
        if (!isShopUIShowing) ui_shop.Show(shopCustomer);
        else ui_shop.Hide();
        isShopUIShowing = !isShopUIShowing;
    }
}
