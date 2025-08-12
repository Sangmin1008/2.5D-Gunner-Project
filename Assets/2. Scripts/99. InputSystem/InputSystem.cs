using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class InputSystem : IInputActionCollection
{
    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public IEnumerator<InputAction> GetEnumerator()
    {
        throw new System.NotImplementedException();
    }

    public bool Contains(InputAction action)
    {
        throw new System.NotImplementedException();
    }

    public void Enable()
    {
        throw new System.NotImplementedException();
    }

    public void Disable()
    {
        throw new System.NotImplementedException();
    }

    public InputBinding? bindingMask { get; set; }
    public ReadOnlyArray<InputDevice>? devices { get; set; }
    public ReadOnlyArray<InputControlScheme> controlSchemes { get; }
}
