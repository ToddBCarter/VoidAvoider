using UnityEngine;

public class HealthPowerUp : MonoBehaviour
{
    [SerializeField] private float healthAmount = 15f;  // how much it heals

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (collision.TryGetComponent<PlayerHealth>(out var playerHealth))
            {
                playerHealth.Heal(healthAmount);
            }

            Destroy(gameObject);
        }
    }
}