using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DarkCloudGame
{
    public class GridBuilder : MonoBehaviour
    {
        [SerializeField] int gridWidth, gridHeight;
        [SerializeField] Vector3 gridOrigin;
        [SerializeField] GameObject spritePrefab;
        [SerializeField] float spriteScale = 1;
        [SerializeField] SOLevelParameters levelParameters;

        Grid grid;
        void Start()
        {
            grid = new Grid(gridWidth, gridHeight, 1, gridOrigin);
            SpawnSpriteOnGrid();
        }

        void SpawnSpriteOnGrid()
        {
            for (int i = 0; i < gridWidth; i++)
            {
                for (int j = 0; j < gridHeight; j++)
                {
                   GameObject spriteInstance = Instantiate(spritePrefab, new Vector3(i + gridOrigin.x, j + gridOrigin.y), Quaternion.identity);
                   spriteInstance.transform.localScale = new Vector3(spriteScale, spriteScale, spriteScale);

                    SetGridValues(i, j);
                    SetCellColor(spriteInstance, i, j);
                }
            }
        }

       
        void SetGridValues(int i, int j)
        {
            float rand = Random.value;

            if (rand < 0.1f)
            {
                grid.GridArrayValues[i, j] = 2;
            }
            else if ((j + i) % 2 == 0)
            {
                grid.GridArrayValues[i, j] = 0;
            }
            else
            {
                grid.GridArrayValues[i, j] = 1;
            }
        }

        void SetCellColor(GameObject go, int i, int j)
        {
            go.GetComponent<SpriteRenderer>().color = levelParameters.cellColor[(int)grid.GridArrayValues[i, j]];
        }
    }
}
