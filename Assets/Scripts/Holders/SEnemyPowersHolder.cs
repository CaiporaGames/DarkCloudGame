using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DarkCloudGame
{
    public class SEnemyPowersHolder : MonoBehaviour
    {
        [SerializeField] GameObject[] enemyPowersPrefab;


        public static SEnemyPowersHolder _instance;
        public static SEnemyPowersHolder Instance { get { return _instance; } }
        public GameObject[] EnemyPowersPreafb { get { return enemyPowersPrefab; } }

        private void Awake()
        {
            if (_instance != this && _instance != null)
            {
                Destroy(gameObject);
            }
            else
            {
                _instance = this;
            }
        }
    }
}
