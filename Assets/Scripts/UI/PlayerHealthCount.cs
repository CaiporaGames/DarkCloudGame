using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace DarkCloudGame
{
    public class PlayerHealthCount : MonoBehaviour
    {
        [SerializeField] SOPlayerStats playerStats;
        [SerializeField] TextMeshProUGUI playerHealthText;

        private void OnEnable()
        {
            SOPlayerStats.setupPlayerHealthDelegate += PlayerHealthText;
        }

        private void Start()
        {
            PlayerHealthText();
        }

        void PlayerHealthText()
        {
            playerHealthText.text = playerStats.playerHealth.ToString();
        }


        private void OnDisable()
        {
            SOPlayerStats.setupPlayerHealthDelegate -= PlayerHealthText;
        }

    }
}
