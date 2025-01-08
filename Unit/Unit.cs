using UnityEngine;

public abstract class Unit : MonoBehaviour
{
    public Animator Animator;
    public Transform ThisTransform;

    private static string AnimParam_MoveSpeed;

    void Awake()
    {
        Animator = GetComponent<Animator>();
        ThisTransform = this.transform;
    }

    public void Idle()
    {
        SetAniMoveSpeed(0);
    }

    public void SetAniMoveSpeed(float speed)
    {
        Animator.SetFloat(AnimParam_MoveSpeed, speed);
    }

    public float GetAniMoveSpeed()
    {
        return Animator.GetFloat(AnimParam_MoveSpeed);
    }
}
