using UnityEngine;
using System;

public class PlayerInteract : MonoBehaviour
{
    private bool inInteractZone = false;

    public event Action enteredInteractZone;
    public event Action exitedInteractZone;

    private void Start()
    {
        PlayerInput.instance.onInteractKeyPressed += Interact;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Interact"))
        {
            inInteractZone = true;
            enteredInteractZone?.Invoke();
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Interact"))
        {
            inInteractZone = false;
            exitedInteractZone?.Invoke();
        }
    }

    private void Interact()
    {
        if (inInteractZone) Debug.Log("Interact");
    }
}
