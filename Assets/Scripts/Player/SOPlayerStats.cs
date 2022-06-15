using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DarkCloudGame
{

    [CreateAssetMenu(menuName = "Scriptable Objects / Player Stats", fileName = "Player Stats")]
    public class SOPlayerStats : ScriptableObject
    {
        public string playerName;
        public float playerHealth;
        public float playerAttack;
        public float maxHealth = 100f;


        public delegate void SetupPlayerHealthDelegate();
        public static SetupPlayerHealthDelegate setupPlayerHealthDelegate;

        public float SetupPlayerHealth(float value)
        {
            if (playerHealth > maxHealth || playerHealth < 0)
            {
                return playerHealth;
            }

            playerHealth += value;
            setupPlayerHealthDelegate?.Invoke();

            return playerHealth;
        }
    }
}

