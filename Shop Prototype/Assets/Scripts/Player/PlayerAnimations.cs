using UnityEngine;

//This script focuses on updating the variables in the animator to ensure that all animations work as intended
[RequireComponent(typeof(PlayerInput))]
public class PlayerAnimations : MonoBehaviour
{
    private Animator animator;
    private PlayerInput playerInput;

    private void Start()
    {
        try
        {
            animator = GetComponentInChildren<Animator>();
            playerInput = GetComponent<PlayerInput>();
            if (animator == null || playerInput == null) throw new System.Exception("PlayerAnimations could not locate the Animator or PlayerInput components in the player's children");
        }
        catch(System.Exception e)
        {
            Debug.LogException(e);
        }
    }

    private void Update()
    {
        Vector2 movement = playerInput.GetVelocity();
        bool isMoving = movement.sqrMagnitude > 0.01f;
        animator.SetBool("IsMoving", movement.sqrMagnitude > 0.01f);
        if (isMoving)
        {
            animator.SetFloat("Horizontal", movement.x);
            animator.SetFloat("Vertical", movement.y);
        }

    }
}
