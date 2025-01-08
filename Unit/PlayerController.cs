using UnityEngine;

public class PlayerController : Unit
{

    private void FixedUpdate()
    {
        Vector3 dir = InputManager.Instance.InputDirection;
        if (dir != Vector3.zero)
        {
            dir.z = dir.y;
            dir.y = 0;
            Move(dir); 
        }
        else
        {
            Idle();
        }
    }
}
