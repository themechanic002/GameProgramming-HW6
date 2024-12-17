using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class EnemyLife : MonoBehaviour
{
    public float amount;
    public UnityEvent onEnemyDeath;

    public Slider HealthBar;

    private void Start()
    {
        amount = 100f;
        HealthBar.maxValue = amount;
        HealthBar.value = amount;
    }

    void Update()
    {
        HealthBar.value = amount;

        if (amount <= 0f)
        {
            onEnemyDeath.Invoke();
            Destroy(gameObject);
        }
    }
}