using UnityEngine;

//Calls the mirror UI to be toggled on
public class MirrorSpot : MonoBehaviour, Interaction
{
    private BaseShop ui_mirror;

    private bool isShopUIShowing = false;

    private void Start()
    {
        try
        {
            ui_mirror = GameObject.Find("UI_Mirror").GetComponent<UI_Mirror>();
            if (ui_mirror == null) throw new System.Exception("ShopSpot could not locate ui_mirror in the scene");
        }
        catch (System.Exception e)
        {
            Debug.LogException(e);
        }

    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            ui_mirror.Hide();
            isShopUIShowing = false;
        }
    }

    public void Interact(IShopCustomer shopCustomer)
    {
        if (!isShopUIShowing) ui_mirror.Show(shopCustomer);
        else ui_mirror.Hide();
        isShopUIShowing = !isShopUIShowing;
    }
}