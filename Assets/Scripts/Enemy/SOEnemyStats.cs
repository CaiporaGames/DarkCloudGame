using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DarkCloudGame
{
    [CreateAssetMenu(menuName = "Scriptable Objects / Enemy Stats", fileName = "Enemy Stats")]
    public class SOEnemyStats
    {
        public string enemyName;
        public float enemyHealth;
        public float enemyAttack;
    }
}
