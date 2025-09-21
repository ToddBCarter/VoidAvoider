using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float pullSpeed = 1f;
    [SerializeField] private float xLimit = 0f;

    [SerializeField] private float escapeDistance = 5f;
    [SerializeField] private float destroyDistance = 10f;
    [SerializeField] private float finalScale = 0.1f;
    [SerializeField] private float shrinkDuration = 1f;
    [SerializeField] private float rotationSpeed = 10f;

    private InputAction moveAction;
    private Vector2 moveInput;
    private float halfHeight;
    private float halfWidth;

    private bool isShrinking = false;

    public float MoveSpeed
    {
        get => moveSpeed;
        set => moveSpeed = value;
    }

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
        if (isShrinking)
        {
            return;
        }

        moveInput = moveAction.ReadValue<Vector2>();
        Vector3 move = new Vector2(moveInput.x, moveInput.y).normalized * (moveSpeed * Time.deltaTime);
        transform.position += move;

        transform.position += pullSpeed * Time.deltaTime * Vector3.left;

        float minX = -halfWidth + 0.5f;
        float clampedX = Mathf.Clamp(transform.position.x, minX, xLimit);
        float clampedY = Mathf.Clamp(transform.position.y, -halfHeight + 0.5f, halfHeight - 0.5f);
        transform.position = new Vector3(clampedX, clampedY, 0f);

        if (transform.position.x < Camera.main.transform.position.x - destroyDistance)
        {
            StartCoroutine(Shrink());
        }
    }

    private IEnumerator Shrink()
    {
        isShrinking = true;
        moveSpeed = 1f; // optional slow down during shrink

        Vector3 startScale = transform.localScale;
        Vector3 targetScale = new(finalScale, finalScale, startScale.z);

        float elapsedTime = 0f;

        while (elapsedTime < shrinkDuration)
        {
            float t = elapsedTime / shrinkDuration;
            t = 1f - Mathf.Pow(1f - t, 3);

            transform.localScale = Vector3.Lerp(startScale, targetScale, t);
            transform.Rotate(Vector3.forward, rotationSpeed * Time.deltaTime);

            elapsedTime += Time.deltaTime;
            yield return null;
        }

        transform.localScale = targetScale;
        Destroy(gameObject);
    }

    public void AddDistanceBoost(float amount)
    {
        xLimit += amount;

        if (xLimit >= escapeDistance)
        {
            Debug.Log("Player wins!");
        }
    }

}