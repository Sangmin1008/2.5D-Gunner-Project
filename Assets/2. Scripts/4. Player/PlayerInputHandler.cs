using System;
using UnityEngine;

public class PlayerInputHandler : MonoBehaviour
{
    public InputSystem_Actions PlayerInput { get; private set; }
    public InputSystem_Actions.PlayerActions PlayerAction { get; private set; }

    private void Awake()
    {
        PlayerInput = new InputSystem_Actions();
        PlayerAction = PlayerInput.Player;
    }

    private void OnEnable()
    {
        PlayerInput.Enable();
    }

    private void OnDisable()
    {
        PlayerInput.Disable();
    }
}
