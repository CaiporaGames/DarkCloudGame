using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DarkCloudGame
{
    public class EnemyPowerAttack : MonoBehaviour
    {
        [SerializeField] SOPlayerStats playerStats;
        [SerializeField] SOEnemyStats enemyStats;
        [SerializeField] float speed = 0.01f;

        Vector3 direction;
        float perc = 0, time = 0, maxTime = 3;
       

        private void OnEnable()
        {
            direction = SPlayerHolder.Instance.Player.transform.position - transform.position;
            StartCoroutine(Timer());
        }
        private void Update()
        {
            transform.Translate(direction * speed * Time.deltaTime);
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("Player"))
            {
                playerStats.SetupPlayerHealth((int)enemyStats.enemyAttack);
                gameObject.SetActive(false);
            }
        }

        private IEnumerator Timer()
        {

            while (perc < 1)
            {
                yield return null;
                time += Time.deltaTime;
                perc = time / maxTime;
            }
            gameObject.SetActive(false);
            time = 0;
            perc = 0;

        }
    }
}
