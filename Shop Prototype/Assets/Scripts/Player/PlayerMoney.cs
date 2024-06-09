using System;
using UnityEngine;

public class PlayerMoney : MonoBehaviour
{
    private static PlayerMoney _instance;

    public event Action onGoldAmountChanged;

    public static PlayerMoney instance
    {
        get
        {
            if (_instance == null) _instance = (Instantiate(Resources.Load("PlayerMoney")) as GameObject).GetComponent<PlayerMoney>();
            return _instance;
        }
    }

    [SerializeField] private int gold = 500;

    public int GetGold()
    {
        return gold;
    }

    public bool SpendGold(int goldAmount)
    {
        if (gold - goldAmount >= 0) gold -= goldAmount;
        else return false;
        onGoldAmountChanged?.Invoke();
        return true;
    }
}
