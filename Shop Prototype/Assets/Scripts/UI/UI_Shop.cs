using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UI_Shop : MonoBehaviour, BaseShop
{
    [Header("Shop Settings")]
    [SerializeField] private int ItemAmount = 8;
    [SerializeField] private float heightExtraOffset = 10f;

    private Transform container;
    private Transform shopItemTemplate;

    private IShopCustomer shopCustomer;

    private float shopItemHeight;

    private void Awake()
    {
        try
        {
            container = transform.Find("Container");
            shopItemTemplate = container.Find("ShopItemTemplate");
            if (shopItemTemplate != null && container != null)
            {
                shopItemTemplate.gameObject.SetActive(false);
                shopItemHeight = shopItemTemplate.GetComponent<RectTransform>().rect.height + heightExtraOffset;
            }
            else throw new System.Exception("UI_Shop could not find ShopItemTemplate and/or Container");
        }
        catch (System.Exception e)
        {
            Debug.LogException(e);
        }

    }

    private void Start()
    {
        for (int i = 0; i < ItemAmount; i++)
        {
            CreateItemButton(GameAssets.instance.GetItens()[i], i);
        }
        Hide();
    }

    private void CreateItemButton(Item item, int positionIndex)
    {
        Transform shopItemTransform = Instantiate(shopItemTemplate, container);
        RectTransform shopItemRectTransform = shopItemTransform.GetComponent<RectTransform>();
        shopItemRectTransform.anchoredPosition = new Vector2(0, -shopItemHeight * positionIndex);

        shopItemRectTransform.Find("ItemNameText").GetComponent<TextMeshProUGUI>().SetText(item.GetItemName());
        shopItemRectTransform.Find("PriceText").GetComponent<TextMeshProUGUI>().SetText(item.GetItemCost().ToString());

        Transform tmpItemIconReference = shopItemRectTransform.Find("ItemIcon");
        float tmpScale = item.GetItemIconScale();
        tmpItemIconReference.localScale = new Vector3(tmpScale, tmpScale, tmpScale);
        tmpItemIconReference.transform.position = tmpItemIconReference.transform.position - new Vector3(0f, item.GetItemIconYOffset(), 0f);
        tmpItemIconReference.GetComponent<Image>().sprite = item.GetItemIcon();

        shopItemTransform.GetComponent<Button>().onClick.AddListener(() => { TryBuyItem(item); });

        shopItemTransform.gameObject.SetActive(true);
    }

    private void TryBuyItem(Item item)
    {
        if (shopCustomer.TrySpendGoldAmount(item.GetItemCost())) shopCustomer.BoughtItem(item);
    }

    public void Show(IShopCustomer shopCustomer)
    {
        this.shopCustomer = shopCustomer;
        gameObject.SetActive(true);
    }
    
    public void Hide()
    {
        gameObject.SetActive(false);
    }
}
