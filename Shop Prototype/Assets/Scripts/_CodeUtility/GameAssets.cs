/*============================================================================================
----------------------------------------REFERENCE CLASS---------------------------------------
This class is used to reference game objects in other classes without having to associate them
via the editor in the script, thus organizing the code and keeping references centralized.
============================================================================================*/
using UnityEngine;

public class GameAssets : MonoBehaviour
{
    private static GameAssets _instance;

    public static GameAssets instance
    {
        get
        {
            if (_instance == null) _instance = (Instantiate(Resources.Load("GameAssets")) as GameObject).GetComponent<GameAssets>();
            return _instance;
        }
    }

    //Loaded on Awake, by searching for the player only once and then using that reference across all scripts, it improves code performance
    private GameObject Player;

    private void Awake()
    {
        try
        {
            Player = GameObject.Find("Player");
            if (Player == null) throw new System.Exception("GameAssets couldn't locate the Player.");
        }
        catch (System.Exception e)
        {
            Debug.LogException(e);
        }
        
    }

    //Getters
    public GameObject GetPlayer()
    {
        return Player;
    }
}
