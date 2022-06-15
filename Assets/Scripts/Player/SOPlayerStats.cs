using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DarkCloudGame
{

    [CreateAssetMenu(menuName = "Scriptable Objects / Player Stats", fileName = "Player Stats")]
    public class SOPlayerStats : ScriptableObject//Basic player information. OBS.: Shouldnt be loading player data.
    {
        public string playerName;
        public float playerHealth;
        public float playerAttack;
        public float maxHealth = 100f;
        [SerializeField] SOJSONUtiles JSONUtils;

        public delegate void SetupPlayerHealthDelegate();
        public static SetupPlayerHealthDelegate setupPlayerHealthDelegate;


        private void OnEnable()
        {
            playerHealth = JSONUtils.LoadGameData().playerHealth;
        }

        public float SetupPlayerHealth(float value)
        {
            playerHealth -= value;

            if (playerHealth > maxHealth)
            {
                playerHealth = 100;
                setupPlayerHealthDelegate?.Invoke();
                return playerHealth;

            }
            else if (playerHealth < 0)
            {
                playerHealth = 0;
                setupPlayerHealthDelegate?.Invoke();
                return playerHealth;
            }

            setupPlayerHealthDelegate?.Invoke();
            return playerHealth;
        }
    }
}

