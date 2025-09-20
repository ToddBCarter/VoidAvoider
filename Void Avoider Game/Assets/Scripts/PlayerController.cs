using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float pullSpeed = 1f;
    [SerializeField] private float xLimit = 0f;

    private InputAction moveAction;
    private Vector2 moveInput;
    private float halfHeight;
    private float halfWidth;


    private void Awake()
    {
        moveAction = InputSystem.actions.FindAction("Move");

        if (moveAction == null)
        {
            Debug.LogError("No move action");
        }
    }

    void Start()
    {
        Camera cam = Camera.main;
        halfHeight = cam.orthographicSize;
        halfWidth = cam.aspect * halfHeight;
    }

    void Update()
    {
        moveInput = moveAction.ReadValue<Vector2>();

        Vector3 move = new Vector2(moveInput.x, moveInput.y).normalized * moveSpeed * Time.deltaTime;
        transform.position += move;

        transform.position += Vector3.left * pullSpeed * Time.deltaTime;

        float minX = -halfWidth + 0.5f;
        float clampedX = Mathf.Clamp(transform.position.x, minX, xLimit);
        float clampedY = Mathf.Clamp(transform.position.y, -halfHeight + 0.5f, halfHeight - 0.5f);

        transform.position = new Vector3(clampedX, clampedY, 0f);
    }
}