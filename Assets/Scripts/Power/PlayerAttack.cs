using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DarkCloudGame
{
    public class PlayerAttack : MonoBehaviour
    {
        [SerializeField] SOPlayerStats playerStats;


        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("Obstacle"))
            {
                gameObject.SetActive(false);
            }
            else if (collision.CompareTag("Enemy"))
            {
                collision.GetComponent<EnemyHealth>().GetDamage(playerStats.playerAttack);
                gameObject.SetActive(false);

            }
        }
    }
}
