using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DarkCloudGame
{
    public class EnemySpawner : MonoBehaviour// Setup and spawn the enemies
    {
        [SerializeField] GameObject[] enemyPrefab;
        [SerializeField] SOLevelParameters levelParameters;

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

            SetupEnemies(halthEnemyAmount, 0);
            SetupEnemies(thirdEnemyAmount, 1);
            SetupEnemies(randEnemyAmount - halthEnemyAmount - thirdEnemyAmount, 2);          

        }

        //Setup enemies types. It should use Scripatable objects to avoid the if/else nightmare
        void SetupEnemies(int enemyAmount, int enemyIndexOnEnemyPrefabArray)
        {
            int x, y;

            for (int j = 0; j < enemyAmount; j++)
            {
                x = Random.Range(Mathf.FloorToInt(levelParameters.grid.Width * 0.5f), Mathf.FloorToInt(levelParameters.grid.Width));
                y = Random.Range(Mathf.FloorToInt(levelParameters.grid.Height * 0.5f), Mathf.FloorToInt(levelParameters.grid.Height));

                if (levelParameters.grid.GridArrayValues[x, y] == 0 || levelParameters.grid.GridArrayValues[x, y] == 1)
                {
                    GameObject enemyGO = Instantiate(enemyPrefab[enemyIndexOnEnemyPrefabArray], levelParameters.grid.GridWorldPositions[x, y], Quaternion.identity);
                    SEnemiesHolder.Instance.Enemies.Add(enemyGO);

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
