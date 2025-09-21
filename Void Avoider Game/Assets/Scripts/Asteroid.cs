using UnityEngine;

public class Asteroid : MonoBehaviour
{
    [SerializeField] private float damage = 10f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") &&
            collision.TryGetComponent<PlayerHealth>(out var playerHealth))
        {
            AudioManager.Instance.PlaySound("asteroid");
            playerHealth.TakeDamage(damage);
            Destroy(gameObject);
        }
    }
}