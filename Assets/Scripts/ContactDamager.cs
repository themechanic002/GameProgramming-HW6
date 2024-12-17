using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using UnityEngine.UI;
using System.Collections;


public class ContactDamager : MonoBehaviour
{
    public float damage;


    void OnTriggerEnter(Collider other)
    {

        EnemyLife life = other.GetComponent<EnemyLife>();

        // if this is Player's bullet
        if (gameObject.CompareTag("PlayerBullet"))
        {
            if (!other.CompareTag("Player"))
            {
                Destroy(gameObject);

                if (life != null)
                    life.amount -= damage;
            }
        }

        // if this is Enemy's bullet
        /* if (gameObject.CompareTag("EnemyBullet"))
        {
            if (other.CompareTag("Player"))
            {
                ToggleBlood();

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
        } */

    }

}