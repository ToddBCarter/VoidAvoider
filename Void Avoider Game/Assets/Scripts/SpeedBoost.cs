using UnityEngine;

public class SpeedBoost : MonoBehaviour
{
    [SerializeField] private float speed = 1f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") &&
            collision.TryGetComponent<PlayerController>(out var playerSpeed))
        {
            AudioManager.Instance.PlaySound("speed");
            playerSpeed.MoveSpeed += speed;
            Destroy(gameObject);
        }
    }
}