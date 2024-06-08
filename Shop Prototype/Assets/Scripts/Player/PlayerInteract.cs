using UnityEngine;
using System;

//This class handles the interact input and passes it foward in the interactable object
public class PlayerInteract : MonoBehaviour
{
    public event Action enteredInteractZone;
    public event Action exitedInteractZone;

    private Interaction interactableObject;

    private void Start()
    {
        PlayerInput.instance.onInteractKeyPressed += Interact;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Interact"))
        {
            interactableObject = other.GetComponent<Interaction>();
            enteredInteractZone?.Invoke();
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Interact"))
        {
            interactableObject = null;
            exitedInteractZone?.Invoke();
        }
    }

    private void Interact()
    {
        if (interactableObject != null) interactableObject.Interact();
    }
}
