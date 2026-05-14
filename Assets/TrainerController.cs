using UnityEngine;

public class TrainerController : MonoBehaviour
{
    private Animator animator;

    void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void PlayJumpingJacks()
    {
        animator.Play("JumpingJacks");
    }

    public void PlaySquat()
    {
        animator.Play("Squat");
    }

    public void PlayPushUp()
    {
        animator.Play("PushUp");
    }

    public void PlaySitUp()
    {
        animator.Play("SitUp");
    }
}
