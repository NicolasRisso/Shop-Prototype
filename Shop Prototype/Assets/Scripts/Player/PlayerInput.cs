using UnityEngine;

//Script designed solely to capture player input, with a focus on distributing one script per functionality
public class PlayerInput : MonoBehaviour
{
    private Vector2 velocity;

    private void Update()
    {
        velocity.x = Input.GetAxisRaw("Horizontal");
        velocity.y = Input.GetAxisRaw("Vertical");
    }

    //Getters
    public Vector2 GetVelocity()
    {
        return velocity;
    }
}
