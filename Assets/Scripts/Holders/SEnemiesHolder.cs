using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DarkCloudGame
{
    public class SEnemiesHolder : MonoBehaviour
    {
        List<GameObject> enemies = new List<GameObject>();

        public static SEnemiesHolder _instance;
        public List<GameObject> Enemies { get { return enemies; } }
        public static SEnemiesHolder Instance { get { return _instance; } }

        public delegate void AllEnemiesAreDead();
        public static AllEnemiesAreDead allEnemiesAreDead;


        private void Awake()
        {
            if (_instance != null && _instance != this)
            {
                Destroy(gameObject);
            }
            else
            {
                _instance = this;
            }
        }

       public void RemoveEnemieFromEnemiesList(GameObject go)
        {
            enemies.Remove(go);
            if (enemies.Count <= 0)
            {
                allEnemiesAreDead?.Invoke();
            }
        }
    }
}
