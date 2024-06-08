using UnityEngine;

//Script designed to move the character in fixed updates to mitigate unusual physics interactions
[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    [Header("Movement Configuration")]
    [SerializeField] private float movementSpeed;

    private Rigidbody2D rb;

    private void Start()
    {
        try
        {
            rb = GetComponent<Rigidbody2D>();
            if (rb == null) throw new System.Exception("Please, verify if you have attached Rigidbody2D to the Player.");
        }
        catch (System.Exception e)
        {
            Debug.LogException(e);
        }
    }

    //Applies velocity using fixedDeltaTime to alleviate physics issues and ensure consistent movement across different FPS
    //Normalized velocity ensures there is no extra movement speed while walking diagonally
    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movementSpeed * Time.fixedDeltaTime * PlayerInput.instance.GetVelocity().normalized);
    }
}
