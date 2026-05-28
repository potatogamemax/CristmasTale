using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class BossHealth : MonoBehaviour
{
    public Slider hpSlider;
    public Image fill;

    public int maxHealth = 100;
    public bool alive = true;

    public GameObject winUI;

    float currentHealth;

    public TextMeshProUGUI hpText;

    int targetHealth;

    public float smoothSpeed = 5f;

    void Start()
    {
        currentHealth = maxHealth;
        targetHealth = maxHealth;

        hpSlider.maxValue = maxHealth;
        hpSlider.value = maxHealth;

        // ===== ДОБАВИЛ =====
        hpText.text = targetHealth + " / " + maxHealth;
        // ===================
    }

    void Update()
    {
        // Плавное уменьшение HP
        currentHealth = Mathf.Lerp(currentHealth, targetHealth, Time.deltaTime * smoothSpeed);

        hpSlider.value = currentHealth;

        UpdateColor();

        // Когда полоска почти дошла до 0
        if (!alive && currentHealth <= 0.1f)
        {
            // Показываем победу
            winUI.SetActive(true);

            // Удаляем босса
            Destroy(gameObject);
        }
    }


// ===== ИЗМЕНИЛ =====
// Был просто void
// Теперь public void
public void TakeDamage(int damage)
{
    targetHealth -= damage;

    if (targetHealth <= 0)
    {
        targetHealth = 0;

        alive = false;
    }

    hpText.text = targetHealth + " / " + maxHealth;
}

// ===================

void UpdateColor()
    {
        float percent = currentHealth / maxHealth;

        fill.color = Color.Lerp(Color.red, Color.green, percent);
    }
}