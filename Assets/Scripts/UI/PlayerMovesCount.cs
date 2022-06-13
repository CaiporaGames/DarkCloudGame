using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace DarkCloudGame
{
    public class PlayerMovesCount : MonoBehaviour
    {
        [SerializeField] TextMeshProUGUI playerMovesCount;

        private void OnEnable()
        {
            PlayerMovement.playerValidMovement += MovesTextUpdate;
        }

        void MovesTextUpdate()
        {
            playerMovesCount.text = GameController.Instance.PlayerMovements.ToString();
        }


        private void OnDisable()
        {
            PlayerMovement.playerValidMovement += MovesTextUpdate;
        }
    }
}
