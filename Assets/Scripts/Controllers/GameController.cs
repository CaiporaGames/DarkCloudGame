using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace DarkCloudGame
{
    public class GameController : MonoBehaviour
    {
        [SerializeField] GameObject gameOverCanvas;
        [SerializeField] GameObject explanationBG;
        [SerializeField] GameObject winCanvas;
        [SerializeField] SOGameStats gameStats;
        [SerializeField] SOPlayerStats playerStats;
        [SerializeField] SOJSONUtiles JSONUtils;


        private void OnEnable()
        {
            SOPlayerStats.setupPlayerHealthDelegate += OpenGameOverCanvas;
            SEnemiesHolder.allEnemiesAreDead += OpenWinCanvas;
        }
              

        void OpenWinCanvas()
        {
            winCanvas.SetActive(true);
            gameStats.isGamePaused = true;
           
        }


        void OpenGameOverCanvas()
        {
            if (playerStats.playerHealth > 0)
            {
                return;
            }

            gameOverCanvas.SetActive(true);
            gameStats.isGamePaused = true;

        }

        public void StartGameAgain()
        {
            gameStats.isGamePaused = false;
            playerStats.playerHealth = playerStats.maxHealth;
            SceneManager.LoadScene(0);

        }

        public void OpenExplanationCanvas()
        {
            gameStats.isGamePaused = true;
            explanationBG.SetActive(true);
        }

        public void ExitExplanationCanvas()
        {
            gameStats.isGamePaused = false;
            explanationBG.SetActive(false);

        }


        private void OnDisable()
        {
            SOPlayerStats.setupPlayerHealthDelegate -= OpenGameOverCanvas;
            SEnemiesHolder.allEnemiesAreDead -= OpenWinCanvas;
        }
    }
}
