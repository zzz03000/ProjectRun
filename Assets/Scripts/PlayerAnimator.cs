using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    private CharacterController player;
    private Animator animator;

    private void Awake()
    {
        player = GetComponentInParent<CharacterController>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (animator == null) return;

        if (player.Horizontal > 0)
            animator.SetFloat("horizontal", 1);
        else if (player.Horizontal < 0)
            animator.SetFloat("horizontal", -1);
        else
            animator.SetFloat("horizontal", 0);

        if (player.YVelocity > 0)
            animator.SetFloat("yVelocity", 1);
        else if (player.YVelocity < 0)
            animator.SetFloat("yVelocity", -1);
        else
            animator.SetFloat("yVelocity", 0);

        if (player.IsDead)
            animator.SetTrigger("isGameOver");
    }
}
