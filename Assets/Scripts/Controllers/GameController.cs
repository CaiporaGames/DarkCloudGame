using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace DarkCloudGame
{
    public class GameController : MonoBehaviour
    {
        [SerializeField] GameObject gameOverCanvas;
        [SerializeField] GameObject winCanvas;
        [SerializeField] SOGameStats gameStats;

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
            gameOverCanvas.SetActive(true);
            gameStats.isGamePaused = true;

        }

        public void StartGameAgain()
        {
            gameStats.isGamePaused = false;
            SceneManager.LoadScene(0);

        }


        private void OnDisable()
        {
            SOPlayerStats.setupPlayerHealthDelegate -= OpenGameOverCanvas;
            SEnemiesHolder.allEnemiesAreDead -= OpenWinCanvas;
        }
    }
}
