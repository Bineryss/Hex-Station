using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private InputAction MoveAction;
    [SerializeField] private float speed = 0.1f;

    private bool disabled;
    void Start()
    {
        MoveAction.Enable();
    }

    void Update()
    {
        if (disabled) return;

        Vector2 move = MoveAction.ReadValue<Vector2>();
        Vector2 positon = (Vector2)transform.position + move * speed * Time.deltaTime;
        transform.position = positon;
    }

    public void DisableMovement()
    {
        disabled = true;
    }
}
