using UnityEngine;

public class AltCollisions : MonoBehaviour
{
    [SerializeField] private float damage = 15f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") &&
            collision.TryGetComponent<PlayerHealth>(out var playerHealth))
        {
            AudioManager.Instance.PlaySound("collision");
            playerHealth.TakeDamage(damage);
            Destroy(gameObject);
        }
    }
}