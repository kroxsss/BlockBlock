using UnityEngine;

public class MenuAnimationController : MonoBehaviour
{
    public Animator animator;

    public void PlayAnimation(string animationName)
    {
        animator.SetTrigger(animationName);
    }
}
