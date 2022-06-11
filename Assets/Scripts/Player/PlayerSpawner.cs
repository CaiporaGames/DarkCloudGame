using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DarkCloudGame
{
    public class PlayerSpawner : MonoBehaviour
    {
        [SerializeField] SOLevelParameters levelParameters;


        private void OnEnable()
        {
            GridBuilder.gridIsReady += SpawnPlayer;
        }

        void SpawnPlayer()
        {
            int x, y;

            RandomGridPosition(out x, out y);

            if (VerifyTileType(x, y))
            {
                transform.position = levelParameters.gridWorldPositions[x,y];
            }
            else
            {
                SpawnPlayer();
            }
        }

        bool VerifyTileType(int i, int j)
        {
            if (levelParameters.gridArrayValues[i,j] == 0 || levelParameters.gridArrayValues[i, j] == 1)
            {
                return true;
            }

            return false;
        }

        void RandomGridPosition(out int x, out int y)
        {
            x = Random.Range(0,Mathf.FloorToInt(levelParameters.gridArrayValues.GetLength(0) * 0.5f));
            y = Random.Range(0, Mathf.FloorToInt(levelParameters.gridArrayValues.GetLength(1) * 0.5f));
        }

        private void OnDisable()
        {
            GridBuilder.gridIsReady -= SpawnPlayer;
        }
    }
}
