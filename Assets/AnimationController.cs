using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    [SerializeField] private PlayerInput playerInput;
    private Animator Animator;
    private SpriteRenderer Renderer;

    const string CHARACTER_SIDERUN = "side_run";
    const string CHARACTER_BACKRUN = "back_run";
    const string CHARACTER_FRONTRUN = "front_run";

    const string CHARACTER_BACKIDLE = "back_idle";
    const string CHARACTER_FRONTIDLE = "front_idle";

    string currentAnimation;
    private void Start()
    {
        Animator = GetComponent<Animator>();
        Renderer = GetComponent<SpriteRenderer>();
    }

    void ChangeAnimation(string Animation)
    {
        if (Animation == currentAnimation) return;
        currentAnimation = Animation;
        Animator.Play(Animation);
    }

    private void Update()
    {
        UpdateAnimation();
    }

   void UpdateAnimation()
    {
        if (playerInput.Y != 0 && playerInput.X != 0) return;
        switch (playerInput.Y)
        {
            case 1:
                ChangeAnimation(CHARACTER_BACKRUN);
                break;
            case -1:
                ChangeAnimation(CHARACTER_FRONTRUN);
                break; 
        }

        switch (playerInput.X)
        {
            case 1:
                ChangeAnimation(CHARACTER_SIDERUN);
                Renderer.flipX = true;
                break;
            case -1:
                ChangeAnimation(CHARACTER_SIDERUN);
                Renderer.flipX = false;
                break;
        }

    }
}
