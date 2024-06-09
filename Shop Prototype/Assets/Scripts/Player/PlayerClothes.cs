using UnityEngine;

//Class focused on changing the players clothes, ended up using it in the NPCs too
public class PlayerClothes : MonoBehaviour
{
    [SerializeField] private GameObject[] bodyClothes;
    [SerializeField] private GameObject[] hairs;
    [SerializeField] private GameObject[] hats;

    private int lastID = -1;

    private bool wasLastToggleOff = false;

    public void ActivateClothe(int id)
    {
        if (id >= 0 && id <= 3)
        {
            ToggleClothing(id, bodyClothes, 0);
        }
        else if (id >= 4 && id <= 5)
        {
            ToggleClothing(id, hairs, 4);
        }
        else if (id >= 6 && id <= 7)
        {
            ToggleClothing(id, hats, 6);
        }
    }

    private void ToggleClothing(int id, GameObject[] clothingArray, int offset)
    {
        foreach (GameObject go in clothingArray)
        {
            go.SetActive(false);
        }

        if (lastID == id && !wasLastToggleOff)
        {
            wasLastToggleOff = true;
        }
        else
        {
            clothingArray[id - offset].SetActive(true);
            wasLastToggleOff = false;
        }

        lastID = id;
    }
}
