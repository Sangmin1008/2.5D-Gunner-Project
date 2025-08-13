using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerRotationHandler : MonoBehaviour
{
    [SerializeField] private float rotationSpeed = 5f;
    [SerializeField] private LayerMask layerMask;
    
    private PlayerInputHandler _playerInput;
    private Vector2 _mouseScreenPosition;
    private Camera _mainCamera;

    private void Awake()
    {
        _playerInput = GetComponent<PlayerInputHandler>();
        _mainCamera = Camera.main;
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
        Rotation();
    }

    private void BindInput()
    {
        var action = _playerInput.PlayerAction;
        action.Look.performed += ReadMousePosition;
        action.Look.canceled += ReadMousePosition;
    }

    private void UnBindInput()
    {
        var action = _playerInput.PlayerAction;
        action.Look.performed -= ReadMousePosition;
        action.Look.canceled -= ReadMousePosition;
        
    }

    private void ReadMousePosition(InputAction.CallbackContext input)
    {
        _mouseScreenPosition = input.ReadValue<Vector2>();
    }


    private void Rotation()
    {
        Ray ray = _mainCamera.ScreenPointToRay(_mouseScreenPosition);

        if (Physics.Raycast(ray, out RaycastHit hit, float.MaxValue, layerMask))
        {
            Vector3 lookDirection = hit.point - transform.position;
            lookDirection.y = 0;

            if (lookDirection.sqrMagnitude > 0.1f)
            {
                Quaternion newRotation = Quaternion.LookRotation(lookDirection);
                transform.rotation = Quaternion.Slerp(transform.rotation, newRotation, rotationSpeed * Time.deltaTime);
            }
        }
    }
}
