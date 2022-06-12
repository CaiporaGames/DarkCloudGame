using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DarkCloudGame
{
    public class EnemySpawner : MonoBehaviour
    {
        [SerializeField] GameObject enemyPrefab;
        [SerializeField] SOLevelParameters levelParameters;

        private void OnEnable()
        {
            GridBuilder.gridIsReady += SpawnEnemies;
        }

        void SpawnEnemies()
        {
            int x, y;
            for (int j = 0; j < 5; j++)
            {
                x = Random.Range(Mathf.FloorToInt(levelParameters.grid.Width * 0.5f), Mathf.FloorToInt(levelParameters.grid.Width));
                y = Random.Range(Mathf.FloorToInt(levelParameters.grid.Height * 0.5f), Mathf.FloorToInt(levelParameters.grid.Height));

                if (levelParameters.grid.GridArrayValues[x,y] == 0 || levelParameters.grid.GridArrayValues[x, y] == 1)
                {
                    GameObject enemyGO = Instantiate(enemyPrefab, levelParameters.grid.GridWorldPositions[x, y] , Quaternion.identity);
                }
                else
                {
                    j--;
                }
            }
            
        }


        private void OnDisable()
        {
            GridBuilder.gridIsReady -= SpawnEnemies;
        }
    }
}
