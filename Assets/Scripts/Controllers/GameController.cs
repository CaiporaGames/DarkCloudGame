using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace DarkCloudGame
{
    public class GameController : MonoBehaviour//It controls the main UI. OBS.: It should be called GameUIController.
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

        private void Start()
        {
            SAudioController.Instance.ChangeMusicClip(2);

        }


        void OpenWinCanvas()
        {
            winCanvas.SetActive(true);
            gameStats.isGamePaused = true;
            SAudioController.Instance.ChangeMusicClip(1);
        }


        void OpenGameOverCanvas()
        {
            if (playerStats.playerHealth > 0)
            {
                return;
            }
            SAudioController.Instance.ChangeMusicClip(0);

            gameOverCanvas.SetActive(true);
            gameStats.isGamePaused = true;
            JSONUtils.SaveGameData(playerStats.playerHealth, gameStats.playerMoves);
        }

        public void StartGameAgain()
        {
            gameStats.isGamePaused = false;
            playerStats.playerHealth = playerStats.maxHealth;
            SAudioController.Instance.ChangeMusicClip(2);
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
