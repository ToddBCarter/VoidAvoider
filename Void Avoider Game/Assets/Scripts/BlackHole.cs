using UnityEngine;

public class BlackHole : MonoBehaviour
{
    public PlayerHealth playerHealth;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerHealth.CurrentHealth = 0;
            EndScreenController endScreenController = FindObjectOfType<EndScreenController>();
            AudioManager.Instance.PlaySound("failure");
            endScreenController.ShowLoss();
        }
    }
}
