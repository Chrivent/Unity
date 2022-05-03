using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayerEffect : MonoBehaviour
{
    Animator animator;
    SpriteRenderer spriteRenderer;

    void Start()
    {
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void PlayUpDownWalk()
    {
        animator.SetBool("UpDownWalk", true);
    }

    public void StopUpDownWalk()
    {
        animator.SetBool("UpDownWalk", false);
    }

    public void PlayLeftWalk()
    {
        spriteRenderer.flipX = false;
        animator.SetBool("LeftRightWalk", true);
    }

    public void PlayRightWalk()
    {
        spriteRenderer.flipX = true;
        animator.SetBool("LeftRightWalk", true);
    }

    public void StopLeftRightWalk()
    {
        animator.SetBool("LeftRightWalk", false);
    }
}
