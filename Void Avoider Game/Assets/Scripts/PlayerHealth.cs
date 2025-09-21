using System.Collections;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private float maxHealth = 100f;
    private float currentHealth;
    private bool isShieldActive = false;

    public EndScreenController endScreenController;

    public float MaxHealth => maxHealth;

    public float CurrentHealth
    {
        get => currentHealth;
        set => currentHealth = value;
    }

    //public float CurrentHealth => currentHealth;
	
	public SpriteRenderer spriteRenderer;
	public Sprite noShield;
	public Sprite shieldOn;

	private float total_duration = 0f;

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
            currentHealth = 0;
            endScreenController.ShowLoss();
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
		total_duration = total_duration + duration;
        StartCoroutine(ShieldTimer(total_duration));
		spriteRenderer.sprite = shieldOn;
    }

    private IEnumerator ShieldTimer(float duration)
    {
		total_duration -= Time.deltaTime;
        yield return new WaitForSeconds(duration);
        isShieldActive = false;
		spriteRenderer.sprite = noShield;
    }


}
