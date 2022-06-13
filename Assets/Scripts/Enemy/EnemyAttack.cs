using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DarkCloudGame
{
    public class EnemyAttack : MonoBehaviour
    {
         GameObject attackPrefab;
        [SerializeField] SOEnemyStats enemyStats;

        private void Start()
        {
            attackPrefab = SEnemyPowersHolder.Instance.EnemyPowersPreafb[enemyStats.enemyType];
        }

        public void Attack()
        {
            attackPrefab.transform.position = transform.position;
            attackPrefab.SetActive(true);
        }      
    }
}
