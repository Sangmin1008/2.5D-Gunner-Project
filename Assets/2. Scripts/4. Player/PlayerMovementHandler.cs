using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovementHandler : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    
    private PlayerInputHandler _playerInput;
    private Vector2 _movementInput;

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

    private void Update()
    {
        Movement();
    }

    private void BindInput()
    {
        var action = _playerInput.PlayerAction;
        action.Move.performed += ReadMovementInput;
        action.Move.canceled += ResetMovementInput;
    }

    private void UnBindInput()
    {
        var action = _playerInput.PlayerAction;
        action.Move.performed -= ReadMovementInput;
        action.Move.canceled -= ResetMovementInput;
    }

    private void ReadMovementInput(InputAction.CallbackContext input)
    {
        _movementInput = input.ReadValue<Vector2>();
    }
    
    private void ResetMovementInput(InputAction.CallbackContext context)
    {
        _movementInput = Vector2.zero;
    }

    private void Movement()
    {
        Vector3 movement = new Vector3(_movementInput.x, 0f, _movementInput.y);
        transform.position += moveSpeed * Time.deltaTime * movement;
    }
}
