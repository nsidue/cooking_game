using UnityEngine;
using UnityEngine.UI;

public class AIHealth : MonoBehaviour
{
    public float health = 10f;
    public Slider healthBar;

    private float damageAmount = 2f;

    void Start()
    {
        healthBar.maxValue = health;
        healthBar.value = health;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("bullet"))
        {
            TakeDamage(damageAmount);
            Destroy(other.gameObject);  
        }
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        healthBar.value = health;

        if (health <= 0)
        {
            Destroy(gameObject);  // Destroy the AI when health reaches 0
        }
    }
}