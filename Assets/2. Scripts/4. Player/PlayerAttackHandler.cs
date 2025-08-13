using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAttackHandler : MonoBehaviour
{
    private PlayerInputHandler _playerInput;

    private void Awake()
    {
        _playerInput = GetComponent<PlayerInputHandler>();
    }

    private void Start()
    {
        BindInput();
    }

    private void OnDisable()
    {
        UnBindInput();
    }

    private void BindInput()
    {
        var action = _playerInput.PlayerAction;
        action.Attack.started += ReadAttackInput;
        action.Attack.canceled += ResetAttackInput;
    }

    private void UnBindInput()
    {
        var action = _playerInput.PlayerAction;
        action.Attack.started -= ReadAttackInput;
        action.Attack.canceled -= ResetAttackInput;
    }

    private void ReadAttackInput(InputAction.CallbackContext _)
    {
        Attack();
    }
    
    private void ResetAttackInput(InputAction.CallbackContext _)
    {
    }

    private void Attack()
    {
        Debug.Log("Attack!");
    }
}
