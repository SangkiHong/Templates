using UnityEngine;

[RequireComponent(typeof(Animator))]
public abstract class Unit : MonoBehaviour
{
    [Header("Setting")]
    [SerializeField] private float speed = 1f;

    [Header("Need")]
    public CharacterController CharacterController;
    public Animator Animator;
    
    public Transform ThisTransform {  get; private set; }

    private static string AnimParam_MoveSpeed = "Speed";

    void Awake()
    {
        ThisTransform = this.transform;
        
        if (CharacterController == null)
            CharacterController = GetComponent<CharacterController>();
        
        if (Animator == null)
            Animator = GetComponent<Animator>();
    }

    public void Idle()
    {
        SetAniMoveSpeed(0);
    }

    public void Move(Vector3 dir)
    {
        ThisTransform.forward = dir;
        CharacterController.Move(speed * Time.fixedDeltaTime * dir);
        SetAniMoveSpeed(dir.magnitude);
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
