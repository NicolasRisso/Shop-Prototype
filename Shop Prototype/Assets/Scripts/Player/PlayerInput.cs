using UnityEngine;
using System;

//Script designed solely to capture player input, with a focus on distributing one script per functionality
//Opted for event-driven architecture over multiple update loops to boost performance and scalability
public class PlayerInput : MonoBehaviour
{
    private static PlayerInput _instance;

    public static PlayerInput instance
    {
        get
        {
            if (_instance == null) _instance = (Instantiate(Resources.Load("PlayerInput")) as GameObject).GetComponent<PlayerInput>();
            return _instance;
        }
    }

    private Vector2 velocity;

    public event Action onInteractKeyPressed;

    private void Update()
    {
        if (Input.GetButtonDown("Interact")) onInteractKeyPressed?.Invoke();

        velocity.x = Input.GetAxisRaw("Horizontal");
        velocity.y = Input.GetAxisRaw("Vertical");
    }

    //Getters
    public Vector2 GetVelocity()
    {
        return velocity;
    }
}
