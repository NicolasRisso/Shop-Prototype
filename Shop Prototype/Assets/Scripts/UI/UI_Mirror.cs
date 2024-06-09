using UnityEngine;
using UnityEngine.UI;
using TMPro;

//Class utilized to create the mirror UI programmatically. Although inheritance could have been employed, time constraints prompted me to opt for a swift coding approach.
public class UI_Mirror : MonoBehaviour, BaseShop
{
    [Header("Mirror Settings")]
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
            shopItemTemplate = container.Find("MirrorItemTemplate");
            if (shopItemTemplate != null && container != null)
            {
                shopItemTemplate.gameObject.SetActive(false);
                shopItemHeight = shopItemTemplate.GetComponent<RectTransform>().rect.height + heightExtraOffset;
            }
            else throw new System.Exception("UI_Mirror could not find MirrorItemTemplate and/or Container");
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

        Transform tmpItemIconReference = shopItemRectTransform.Find("ItemIcon");
        float tmpScale = item.GetItemIconScale();
        tmpItemIconReference.localScale = new Vector3(tmpScale, tmpScale, tmpScale);
        tmpItemIconReference.transform.position = tmpItemIconReference.transform.position - new Vector3(0f, item.GetItemIconYOffset(), 0f);
        tmpItemIconReference.GetComponent<Image>().sprite = item.GetItemIcon();

        shopItemTransform.GetComponent<Button>().onClick.AddListener(() => { TryWearItem(item); });

        shopItemTransform.gameObject.SetActive(true);
    }

    private void TryWearItem(Item item)
    {
        GameAssets.instance.GetPlayer().GetComponentInChildren<PlayerClothes>().ActivateClothe(item.GetID());
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
