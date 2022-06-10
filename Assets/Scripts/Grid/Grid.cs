using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DarkCloudGame
{
    public class Grid
    {
        int width;
        int height;
        float cellSize;
        Vector3 gridOriginPosition;

        int[,] gridArray;

        public Grid(int width, int height, float cellSize, Vector3 gridOriginPosition)
        {
            this.width = width;
            this.height = height;
            this.cellSize = cellSize;
            this.gridOriginPosition = gridOriginPosition;

            gridArray = new int[width, height];
        }

        Vector3 GetWorldPosition(int x, int y)
        {
            return new Vector3(x, y) * cellSize + gridOriginPosition;
        }

        void GetXY(Vector3 worldPosition, out int x, out int y)
        {
            x = Mathf.FloorToInt((worldPosition - gridOriginPosition).x / cellSize);
            y = Mathf.FloorToInt((worldPosition - gridOriginPosition).y / cellSize);
        }

        public void SetValue(int x, int y, int value)
        {
            if (x >= 0 && y >= 0 && x < width && y < height)
            {
                gridArray[x, y] = value;
            }
        }

        public void SetValue(Vector3 worldPosition, int value)
        {
            int x, y;
            GetXY(worldPosition, out x, out y);
            SetValue(x, y, value);
        }

        public int GetValue(int x, int y)
        {
            if (x >= 0 && y >= 0 && x < width && y < height)
            {
                return gridArray[x, y];
            }
            else
            {
                return -1;
            }
        }

        public int GetValue(Vector3 worldPosition)
        {
            int x, y;
            GetXY(worldPosition, out x, out y);
            return GetValue(x, y);
        }
    }
}