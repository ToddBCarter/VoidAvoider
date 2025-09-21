using UnityEngine;

public class BoostPowerUp : MonoBehaviour
{
    [SerializeField] private float boostAmount = 1.5f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") &&
            collision.TryGetComponent<PlayerController>(out var player))
        {
            player.AddDistanceBoost(boostAmount);
            Destroy(gameObject);
        }
    }
}