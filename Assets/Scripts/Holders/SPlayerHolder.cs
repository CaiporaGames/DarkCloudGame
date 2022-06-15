using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DarkCloudGame
{
    public class SPlayerHolder : MonoBehaviour//Holds the player gameobject for future reference
    {
        [SerializeField] GameObject player;

        public static SPlayerHolder _instance;
        public static SPlayerHolder Instance { get { return _instance; } }
        public GameObject Player { get { return player; } }

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
