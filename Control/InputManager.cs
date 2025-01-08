using UnityEngine;
using Templates;
using Utility;

public class InputManager : SingletonPersistent<InputManager>
{
    [SerializeField] private JoystickHandler joystickHandler;

    public Vector3 InputDirection => joystickHandler.Direction;

    private void Awake()
    {
        if (InitSingleton() == false)
        {
            return;
        }
    }
}
