using UnityEngine;

//This script focuses on updating the variables in the animator to ensure that all animations work as intended
public class PlayerAnimations : MonoBehaviour
{
    private Animator animator;

    private void Start()
    {
        try
        {
            animator = GetComponentInChildren<Animator>();
            if (animator == null) throw new System.Exception("PlayerAnimations could not locate the Animator component in the player's children");
        }
        catch(System.Exception e)
        {
            Debug.LogException(e);
        }
    }

    private void Update()
    {
        Vector2 movement = PlayerInput.instance.GetVelocity();
        bool isMoving = movement.sqrMagnitude > 0.01f;
        animator.SetBool("IsMoving", movement.sqrMagnitude > 0.01f);
        if (isMoving)
        {
            animator.SetFloat("Horizontal", movement.x);
            animator.SetFloat("Vertical", movement.y);
        }

    }
}
