using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DarkCloudGame
{
    public class GameController : MonoBehaviour
    {
        public static GameController _instance;
        public GameController Instance { get { return _instance; } }

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


        void ControlGameTurn()
        {

        }
        

        void SelectEnemyToAttackPlayer()
        {
            //Select enemy

            //call the attack method from the enemy
        }
    }
}
