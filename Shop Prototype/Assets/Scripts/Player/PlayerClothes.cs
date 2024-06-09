using UnityEngine;

//Class focused on changing the players clothes, ended up using it in the NPCs too
public class PlayerClothes : MonoBehaviour
{
    [SerializeField] private GameObject[] bodyClothes;
    [SerializeField] private GameObject[] hairs;
    [SerializeField] private GameObject[] hats;

    private int lastID;

    public void ActivateClothe(int id)
    {
        if (id >= 0 && id <= 3)
        {
            foreach (GameObject go in bodyClothes)
            {
                go.SetActive(false);
            }
            if (lastID != id) bodyClothes[id].SetActive(true);
            else lastID = -1;
        }
        else if (id >= 4 && id <= 5)
        {
            foreach (GameObject go in hairs)
            {
                go.SetActive(false);
            }
            if (lastID != id) hairs[id - 4].SetActive(true);
            else lastID = -1;
        }
        else if (id >= 6 && id <= 7)
        {
            foreach (GameObject go in hats)
            {
                go.SetActive(false);
            }
            if (lastID != id) hats[id - 6].SetActive(true);
            else lastID = -1;
        }
        lastID = id;
    }
}
