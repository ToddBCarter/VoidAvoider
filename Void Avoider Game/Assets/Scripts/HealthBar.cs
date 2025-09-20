using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private PlayerHealth playerHealth;
    [SerializeField] private Slider slider;

    void Awake()
    {
        slider.maxValue = playerHealth.MaxHealth;
        slider.value = playerHealth.CurrentHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
