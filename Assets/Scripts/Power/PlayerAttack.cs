using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DarkCloudGame
{
    public class PlayerAttack : MonoBehaviour//This goes on the power of the player. OBS.: Should be called PlayerPowerAttack
    {
        [SerializeField] SOPlayerStats playerStats;


        private void OnTriggerEnter2D(Collider2D collision)
        {
            //We should use scriptable objects to identify the elements that was hit not this if/else nightmare
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
