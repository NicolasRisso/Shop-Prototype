using UnityEngine;
using TMPro;

//Display the players gold on screen
public class GoldUI : MonoBehaviour
{
    private TextMeshProUGUI goldText;

    private void Start()
    {
        try
        {
            goldText = transform.Find("GoldText").GetComponent<TextMeshProUGUI>();
            if (goldText != null)
            {
                PlayerMoney.instance.onGoldAmountChanged += AdjustGoldUI;
                AdjustGoldUI();
            }
            else throw new System.Exception("GoldUI.cs could not locate \"GoldText\"");
        }
        catch (System.Exception e)
        {
            Debug.Log(e);
        }
    }

    private void AdjustGoldUI()
    {
        goldText.SetText(PlayerMoney.instance.GetGold().ToString());
    }
}
