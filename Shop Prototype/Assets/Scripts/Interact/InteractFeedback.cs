using UnityEngine;

//This class focus on turning on and off the feedback icon
[RequireComponent(typeof(PlayerInteract))]
public class InteractFeedback : MonoBehaviour
{
    [SerializeField] private GameObject interactFeedbackIcon;

    private PlayerInteract playerInteract;

    private void Start()
    {
        try
        {
            playerInteract = GetComponent<PlayerInteract>();
            if (playerInteract != null)
            {
                playerInteract.enteredInteractZone += () => { interactFeedbackIcon.SetActive(true); };
                playerInteract.exitedInteractZone += () => { interactFeedbackIcon.SetActive(false); };
            }
            else throw new System.Exception("InteractFeedback could not locate PlayerInteract component");
        }
        catch(System.Exception e)
        {
            Debug.LogException(e);
        }
    }
}