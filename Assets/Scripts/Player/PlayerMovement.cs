using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DarkCloudGame
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] SOLevelParameters levelParameters;
        [SerializeField] Animator animator;
        [SerializeField] SOGameStats gameStats;



        Vector3 playerPosition;
        int x, y;
        int walkID;

        void Awake()
        {
            walkID = Animator.StringToHash("walk");
        }


        private void Update()
        {
            if (gameStats.isGamePaused)
            {
                return;
            }
            PlayerMove();
        }

       void PlayerMove()
        {
            if (Input.GetKeyDown(KeyCode.W) && transform.position.y < levelParameters.grid.GridOriginPosition.y + levelParameters.grid.Height - 1)
            {
               // animator.SetTrigger(walkID);
                VerifyGridObstaclePosition();
                if (levelParameters.gridArrayValues[x,y + 1] == 2 || GameTurnController.Instance.PlayerMovements <= 0)
                {
                    return;
                }
                GameTurnController.Instance.ReducePlayerMovements();
                playerPosition = transform.position;
                transform.position = new Vector3(Mathf.FloorToInt(playerPosition.x), Mathf.FloorToInt(playerPosition.y + 1));
            }
            else if (Input.GetKeyDown(KeyCode.S) && transform.position.y > levelParameters.grid.GridOriginPosition.y)
            {
                VerifyGridObstaclePosition();
                //animator.SetTrigger(walkID);
                if (levelParameters.gridArrayValues[x, y - 1] == 2 || GameTurnController.Instance.PlayerMovements <= 0)
                {
                    return;
                }
                GameTurnController.Instance.ReducePlayerMovements();
                playerPosition = transform.position;
                transform.position = new Vector3(Mathf.FloorToInt(playerPosition.x), Mathf.FloorToInt(playerPosition.y - 1));
            }
            else if (Input.GetKeyDown(KeyCode.D) && transform.position.x < levelParameters.grid.GridOriginPosition.x + levelParameters.grid.Width - 1)
            {
                VerifyGridObstaclePosition();
                // animator.SetTrigger(walkID);
                if (levelParameters.gridArrayValues[x + 1, y] == 2 || GameTurnController.Instance.PlayerMovements <= 0)
                {
                    return;
                }
                GameTurnController.Instance.ReducePlayerMovements();
                playerPosition = transform.position;
                transform.position = new Vector3(Mathf.FloorToInt(playerPosition.x + 1), Mathf.FloorToInt(playerPosition.y));
            }
            else if (Input.GetKeyDown(KeyCode.A) && transform.position.x > levelParameters.grid.GridOriginPosition.x)
            {
                VerifyGridObstaclePosition();
                // animator.SetTrigger(walkID);
                if (levelParameters.gridArrayValues[x - 1, y] == 2 || GameTurnController.Instance.PlayerMovements <= 0)
                {
                    return;
                }
                GameTurnController.Instance.ReducePlayerMovements();
                playerPosition = transform.position;
                transform.position = new Vector3(Mathf.FloorToInt(playerPosition.x - 1), Mathf.FloorToInt(playerPosition.y));
            }
        }

        void VerifyGridObstaclePosition()
        {
            levelParameters.grid.GetXY(transform.position, out x, out y);

        }

    }
}
