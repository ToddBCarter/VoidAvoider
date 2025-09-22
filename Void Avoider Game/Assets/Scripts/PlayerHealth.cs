using System.Collections;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private float maxHealth = 100f;
    private float currentHealth;
    private bool isShieldActive = false;
    private float shieldDuration = 0f;

    public EndScreenController endScreenController;
    [SerializeField] LevelTimer LevelTimer;

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
            AudioManager.Instance.PlaySound("failure");
            AudioManager.Instance.ChangeBackgroundMusic(AudioManager.Instance.MenuMusic, 0.4f, true);
            Debug.Log("Ship destroyed!");
            gameObject.SetActive(false);
            currentHealth = 0;
            if (!GameManager.Instance.endlessMode == true)
            {
                endScreenController.ShowLoss();
            }
            else
            {
                string message = "Time survived: " + LevelTimer.FormatTime(LevelTimer.EndlessTime);
                endScreenController.ShowLoss(message);
            }
        }
    }

    public void Heal(float addedHealth)
    {
        currentHealth += addedHealth;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
    }

    public void ActivateShield(float duration)
    {
        shieldDuration += duration;

        if (!isShieldActive)
        {
            isShieldActive = true;
            spriteRenderer.sprite = shieldOn;
            StartCoroutine(ShieldTimer());
        }
    }

    private IEnumerator ShieldTimer()
    {
        while (shieldDuration > 0f)
        {
            shieldDuration -= Time.deltaTime;
            Debug.Log("shield duration in coroutine: " + shieldDuration);
            yield return null;
        }

        shieldDuration = 0f;
        isShieldActive = false;
		spriteRenderer.sprite = noShield;
    }
}
