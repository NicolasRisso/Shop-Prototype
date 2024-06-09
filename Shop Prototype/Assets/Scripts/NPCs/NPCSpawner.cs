using UnityEngine;

//Spawns NPCs from time to time to buy player itens
public class NPCSpawner : MonoBehaviour
{
    [SerializeField] private GameObject npcPrefab;
    [SerializeField] private float spawnInterval = 5f;

    void Start()
    {
        InvokeRepeating("SpawnNPC", 0f, spawnInterval);
    }

    void SpawnNPC()
    {
        if (npcPrefab != null)
        {
            Instantiate(npcPrefab, transform.position, Quaternion.identity);
        }
        else
        {
            Debug.LogError("NPC prefab or spawn point not set.");
        }
    }
}
