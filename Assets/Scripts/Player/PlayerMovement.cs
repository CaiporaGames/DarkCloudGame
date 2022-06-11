using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DarkCloudGame
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] SOLevelParameters levelParameters;
        Vector3 playerPosition;

        private void Update()
        {
            PlayerMove();
        }

       void PlayerMove()
        {
            if (Input.GetKeyDown(KeyCode.W) && transform.position.y < levelParameters.grid.GridOriginPosition.y + levelParameters.grid.Height - 1)
            {
                playerPosition = transform.position;
                transform.position = new Vector3(Mathf.FloorToInt(playerPosition.x), Mathf.FloorToInt(playerPosition.y + 1));
            }
            else if (Input.GetKeyDown(KeyCode.S) && transform.position.y > levelParameters.grid.GridOriginPosition.y)
            {
                playerPosition = transform.position;
                transform.position = new Vector3(Mathf.FloorToInt(playerPosition.x), Mathf.FloorToInt(playerPosition.y - 1));
            }
            else if (Input.GetKeyDown(KeyCode.D) && transform.position.x < levelParameters.grid.GridOriginPosition.x + levelParameters.grid.Width - 1)
            {
                playerPosition = transform.position;
                transform.position = new Vector3(Mathf.FloorToInt(playerPosition.x + 1), Mathf.FloorToInt(playerPosition.y));
            }
            else if (Input.GetKeyDown(KeyCode.A) && transform.position.x > levelParameters.grid.GridOriginPosition.x)
            {
                playerPosition = transform.position;
                transform.position = new Vector3(Mathf.FloorToInt(playerPosition.x - 1), Mathf.FloorToInt(playerPosition.y));
            }
        }

        void VerifyGridObstaclePosition()
        {

        }

    }
}
