using UnityEngine;

//This script is designed to ensure the camera follows the player without being attached to the
//same object where the movement physics are applied, thus preventing potential camera flickering.
public class FollowPlayer : MonoBehaviour
{
    [Header("Offset Configuration")]
    [Tooltip("Avoid modifying the z value, as it can potentially cause issues with the camera's position.")]
    [SerializeField] private Vector3 offset;

    private Transform playerTransform;

    //Obtains the player reference using the GameAssets static class, optimizing code performance
    private void Start()
    {
        try
        {
            playerTransform = GameAssets.instance.GetPlayer().transform;
            if (playerTransform == null) throw new System.Exception("Something went wrong when loading Player in FollowPlayer.cs");
        }
        catch (System.Exception e)
        {
            Debug.LogException(e);
        }
    }

    private void Update()
    {
        if (playerTransform != null) transform.position = playerTransform.position + offset;
        else Debug.LogWarning("Player Transform reference not set in FollowPlayer script.");
    }
}
