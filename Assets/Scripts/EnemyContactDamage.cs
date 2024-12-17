using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using UnityEngine.UI;
using System.Collections;


public class EnemyContactDamage : MonoBehaviour
{
    public float damage;


    void OnTriggerEnter(Collider other)
    {

        Life life = other.GetComponent<Life>();

        // if this is Enemy's bullet
        if (gameObject.CompareTag("EnemyBullet"))
        {
            if (other.CompareTag("Player"))
            {

                Destroy(gameObject);

                if (life != null)
                    life.amount -= damage;
            }
            else if (!other.CompareTag("Enemy"))
            {
                Destroy(gameObject);

                if (life != null)
                    life.amount -= damage;
            }
        }

    }

}