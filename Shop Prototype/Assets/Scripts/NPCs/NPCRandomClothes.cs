using UnityEngine;

//Decide a random vest for the NPC to use
public class NPCRandomClothes : MonoBehaviour
{
    private PlayerClothes clothes;

    private void Start()
    {
        clothes = GetComponentInChildren<PlayerClothes>();
        if (clothes != null)
        {
            clothes.ActivateClothe(Random.Range(0, 4));
            clothes.ActivateClothe(Random.Range(4, 6));
            clothes.ActivateClothe(Random.Range(6, 8));
        }
    }
}
