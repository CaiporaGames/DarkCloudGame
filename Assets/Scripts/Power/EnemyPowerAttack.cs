using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DarkCloudGame
{
    public class EnemyPowerAttack : MonoBehaviour
    {
        [SerializeField] SOPlayerStats playerStats;
        [SerializeField] SOEnemyStats enemyStats;
        [SerializeField] float speed = 0.03f;

        Vector3 direction;
        float perc = 0, time = 0, maxTime = 4;
       

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
            Debug.Log(collision.gameObject.name);
            if (collision.CompareTag("Player"))
            {
                playerStats.SetupPlayerHealth(enemyStats.enemyAttack);
                gameObject.SetActive(false);
            }
            else if (collision.CompareTag("Obstacle"))
            {
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
