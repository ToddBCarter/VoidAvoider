using System.Collections;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private float maxHealth = 100f;
    private float currentHealth;
    private bool isShieldActive = false;

    public float MaxHealth => maxHealth;
    public float CurrentHealth => currentHealth;

    private void Awake()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(float damage)
    {
        if (isShieldActive)
        {
            return;
        }

        currentHealth -= damage;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);

        Debug.Log($"Ship took {damage} damage. Health: {currentHealth}");

        if (currentHealth <= 0)
        {
            Debug.Log("Ship destroyed!");
            gameObject.SetActive(false);
        }
    }

    public void Heal(float addedHealth)
    {
        currentHealth += addedHealth;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
    }

    public void ActivateShield(float duration)
    {
        isShieldActive = true;
        StartCoroutine(ShieldTimer(duration));
    }

    private IEnumerator ShieldTimer(float duration)
    {
        yield return new WaitForSeconds(duration);
        isShieldActive = false;
    }


}
