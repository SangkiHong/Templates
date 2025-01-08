using UnityEngine;

[RequireComponent(typeof(Animator))]
public abstract class Unit : MonoBehaviour
{
    public Animator Animator;
    
    public Transform ThisTransform {  get; private set; }

    private static string AnimParam_MoveSpeed;

    void Awake()
    {
        ThisTransform = this.transform;
        
        if (Animator == null)
            Animator = GetComponent<Animator>();
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
