
using UnityEngine;

public class ExplosionOnDeath : MonoBehaviour
{
    public GameObject particlePrefab;

    void Awake()
    {
        var enemyLife = GetComponent<EnemyLife>();
        enemyLife.onEnemyDeath.AddListener(OnEnemyDeath);
    }

    void OnEnemyDeath()
    {

        // Instantiate the particle system higher than the enemy
        var particle = Instantiate(particlePrefab, transform.position + Vector3.up * 1.8f, Quaternion.identity);
    }
}


