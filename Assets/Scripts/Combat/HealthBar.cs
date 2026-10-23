using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider slider;
    public Slider sliderEffect;
    public Slider shieldSlider;
    [SerializeField] private float delay = 5.0f;
    [SerializeField] private float duration = 1.0f;
    private Coroutine healthEffectCoroutine;


    public void SetMaxHealth(int maxHealth)
    {
        shieldSlider.maxValue = maxHealth;
        shieldSlider.value = 0;
        slider.maxValue = maxHealth;
        slider.value = maxHealth;
        sliderEffect.maxValue = maxHealth;
        sliderEffect.value = maxHealth;
    }
    public void SetHealth(int health)
    {
        slider.value = health;
        if (healthEffectCoroutine != null)
            StopCoroutine(healthEffectCoroutine);
        healthEffectCoroutine = StartCoroutine(AnimateHealthEffect());
    }
    public void SetShield(int shield)
    {
        shieldSlider.value = shield;
    }
     private IEnumerator AnimateHealthEffect()
    {
        yield return new WaitForSeconds(delay);

        float startHealth = sliderEffect.value;
        float targetHealth = slider.value;
        float elapsed = 0f;

        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;

            float t = Mathf.Clamp01(elapsed / duration);

            sliderEffect.value = Mathf.Lerp(
                startHealth,
                targetHealth,
                t
            );

            yield return null;
        }

        sliderEffect.value = targetHealth;
        healthEffectCoroutine = null;
    }
}
