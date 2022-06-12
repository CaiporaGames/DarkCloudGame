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

        public delegate void GridIsReady();
        public static GridIsReady gridIsReady;

        void Start()
        {
            levelParameters.CreateGrid(gridWidth, gridHeight, 1, gridOrigin);
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


                    TileData tileData = spriteInstance.GetComponent<TileData>();


                    SetGridValues(tileData, i, j);
                    SetCellColor(spriteInstance, i, j);
                }
            }

            gridIsReady?.Invoke();
        }

        void SetTileValue(TileData tileData, int i, int j)
        {
            tileData.TileValue = levelParameters.gridArrayValues[i, j];
            tileData.TileWorldPosition = levelParameters.gridWorldPositions[i, j];
        }

       
        void SetGridValues(TileData tileData, int i, int j)
        {
            float randomChance = Random.value;

            SetGridDefaultValue(tileData, i, j);


            if (randomChance < 0.1f)
            {
                levelParameters.grid.GridArrayValues[i, j] = 2;
                tileData.HasAnotherElement = true;
            }
            else if(randomChance >= 0.1f && randomChance < 0.15f)
            {
                levelParameters.grid.GridArrayValues[i, j] = 3;
                tileData.HasAnotherElement = true;

            }

            SetTileValue(tileData, i, j);

        }

        void SetGridDefaultValue(TileData tileData, int i, int j)
        {
            if ((j + i) % 2 == 0)
            {
                levelParameters.grid.GridArrayValues[i, j] = 0;
                
            }
            else
            {
                levelParameters.grid.GridArrayValues[i, j] = 1;
            }

            tileData.TileDefaultGroundValue = levelParameters.gridArrayValues[i, j];

        }

        void SetCellColor(GameObject go, int i, int j)
        {
            go.GetComponent<SpriteRenderer>().color = levelParameters.cellColor[(int)levelParameters.grid.GridArrayValues[i, j]];
        }
    }
}
