using MagicPigGames;
using System;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
public class PlayerHealth : MonoBehaviour
{

    [Header("Player Health")]
    public float maxHealth = 100f;
    private float currentHealth;

    [Header("Damage Overlay")]
    public Image overlay;//dmg overal objekat
    public float duration;//koliko dugo slika ostaje vidljiva
    public float fadeSpeed;//koliko se brzo nestaje slika

    private float durationTimer;

    public MagicPigGames.ProgressBar healthBar;
    void Start()
    {
        currentHealth = maxHealth;

        overlay.color = new Color(overlay.color.r, overlay.color.g, overlay.color.b, 0);

        UpdateHealthBar();
    }

    public void TakeDamage(float damage) {
        currentHealth -= damage;
        currentHealth = Mathf.Clamp(currentHealth,0,maxHealth);

        durationTimer = 0;
        overlay.color = new Color(overlay.color.r, overlay.color.g, overlay.color.b, 1);

        UpdateHealthBar();
    }

    void UpdateHealthBar()
    {
        if (healthBar != null) {
            float healthProgress = currentHealth / maxHealth;
            healthBar.SetProgress(healthProgress);
        }
    }

    public void Heal(float healAmount)
    {
        currentHealth += healAmount;  
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth); 

        UpdateHealthBar(); 
    }

    private void Update()
    {

        if (overlay.color.a > 0) {
            if (currentHealth < 10) {
                return;
            }
            durationTimer += Time.deltaTime;
            if (durationTimer > duration)
            {
                float tempAlfa = overlay.color.a;
                tempAlfa -= Time.deltaTime * fadeSpeed;
                overlay.color = new Color(overlay.color.r, overlay.color.g, overlay.color.b, tempAlfa);
            }
        }
    }

}
