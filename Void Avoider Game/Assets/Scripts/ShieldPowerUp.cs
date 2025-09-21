using UnityEngine;

public class ShieldPowerUp : MonoBehaviour
{
    [SerializeField] private float shieldDuration = 5f; // seconds

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") &&
            collision.TryGetComponent<PlayerHealth>(out var playerHealth))
        {
            playerHealth.ActivateShield(shieldDuration);
            Destroy(gameObject);
        }
    }
}