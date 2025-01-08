using UnityEngine;
using Templates;
using Utility;

public class InputManager : SingletonPersistent<InputManager>
{
    [SerializeField] private JoystickHandler joystickHandler;

    private void Awake()
    {
        if (InitSingleton() == false)
        {
            return;
        }
    }
}
