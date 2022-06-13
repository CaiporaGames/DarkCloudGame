using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DarkCloudGame
{
    public class EnemySpawner : MonoBehaviour
    {
        [SerializeField] GameObject[] enemyPrefab;
        [SerializeField] SOLevelParameters levelParameters;
        [SerializeField] int enemyAmount = 5;

        int randEnemyAmount, halthEnemyAmount, thirdEnemyAmount;

        private void OnEnable()
        {
            GridBuilder.gridIsReady += SpawnEnemies;
        }

      
        void SpawnEnemies()
        {

            randEnemyAmount = Random.Range(6, 21);
            halthEnemyAmount = Mathf.RoundToInt(randEnemyAmount * 0.5f);
            thirdEnemyAmount = Mathf.RoundToInt(randEnemyAmount * 0.3f);

            int x, y;
            for (int j = 0; j < halthEnemyAmount; j++)
            {
                x = Random.Range(Mathf.FloorToInt(levelParameters.grid.Width * 0.5f), Mathf.FloorToInt(levelParameters.grid.Width));
                y = Random.Range(Mathf.FloorToInt(levelParameters.grid.Height * 0.5f), Mathf.FloorToInt(levelParameters.grid.Height));

                if (levelParameters.grid.GridArrayValues[x,y] == 0 || levelParameters.grid.GridArrayValues[x, y] == 1)
                {
                    GameObject enemyGO = Instantiate(enemyPrefab[0], levelParameters.grid.GridWorldPositions[x, y] , Quaternion.identity);
                }
                else
                {
                    j--;
                }
            }

            for (int j = 0; j < thirdEnemyAmount; j++)
            {
                x = Random.Range(Mathf.FloorToInt(levelParameters.grid.Width * 0.5f), Mathf.FloorToInt(levelParameters.grid.Width));
                y = Random.Range(Mathf.FloorToInt(levelParameters.grid.Height * 0.5f), Mathf.FloorToInt(levelParameters.grid.Height));

                if (levelParameters.grid.GridArrayValues[x, y] == 0 || levelParameters.grid.GridArrayValues[x, y] == 1)
                {
                    GameObject enemyGO = Instantiate(enemyPrefab[1], levelParameters.grid.GridWorldPositions[x, y], Quaternion.identity);
                }
                else
                {
                    j--;
                }
            }

            for (int j = 0; j < halthEnemyAmount - thirdEnemyAmount; j++)
            {
                x = Random.Range(Mathf.FloorToInt(levelParameters.grid.Width * 0.5f), Mathf.FloorToInt(levelParameters.grid.Width));
                y = Random.Range(Mathf.FloorToInt(levelParameters.grid.Height * 0.5f), Mathf.FloorToInt(levelParameters.grid.Height));

                if (levelParameters.grid.GridArrayValues[x, y] == 0 || levelParameters.grid.GridArrayValues[x, y] == 1)
                {
                    GameObject enemyGO = Instantiate(enemyPrefab[2], levelParameters.grid.GridWorldPositions[x, y], Quaternion.identity);
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
