using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace DarkCloudGame
{
    public class PlayerMovesCount : MonoBehaviour//This is for the UI and should be called PlayerMovementUI
    {
        [SerializeField] TextMeshProUGUI playerMovesCount;

        private void OnEnable()
        {
            GameTurnController.reducePlayerMovementsCount += MovesTextUpdate;
        }

        void MovesTextUpdate()
        {
            playerMovesCount.text = GameTurnController.Instance.PlayerMovements.ToString();
        }


        private void OnDisable()
        {
            GameTurnController.reducePlayerMovementsCount -= MovesTextUpdate;
        }
    }
}
