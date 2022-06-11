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

        float[,] gridArrayValues;
        Vector3[,] gridWorldPositions;

        public Grid(int width, int height, float cellSize, Vector3 gridOriginPosition)
        {
            this.width = width;
            this.height = height;
            this.cellSize = cellSize;
            this.gridOriginPosition = gridOriginPosition;

            gridArrayValues = new float[width, height];
            gridWorldPositions = new Vector3[width, height];
            CreateGridWorldPositions();
        }

        public float[,] GridArrayValues { get { return gridArrayValues; } }
        public Vector3[,] GridWorldPositions { get { return gridWorldPositions; } }

        public Vector3 GridOriginPosition { get { return gridOriginPosition; } }

        public int Width { get { return width; } }
        public int Height { get { return height; } }

        Vector3[,] CreateGridWorldPositions()
        {

            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    gridWorldPositions[i, j] = new Vector3(i * cellSize + gridOriginPosition.x, j * cellSize + gridOriginPosition.y);
                }
            }

            return gridWorldPositions;
        }

        Vector3 GetWorldPosition(float x, float y)
        {
            return new Vector3(x, y) * cellSize + gridOriginPosition;
        }

        void GetXY(Vector3 worldPosition, out int x, out int y)
        {
            x = Mathf.FloorToInt((worldPosition - gridOriginPosition).x / cellSize);
            y = Mathf.FloorToInt((worldPosition - gridOriginPosition).y / cellSize);
        }

        public void SetValue(int x, int y, float value)
        {
            if (x >= 0 && y >= 0 && x < width && y < height)
            {
                gridArrayValues[x, y] = value;
            }
        }

        public void SetValue(Vector3 worldPosition, float value)
        {
            int x, y;
            GetXY(worldPosition, out x, out y);
            SetValue(x, y, value);
        }

        public float GetValue(int x, int y)
        {
            if (x >= 0 && y >= 0 && x < width && y < height)
            {
                return gridArrayValues[x, y];
            }
            else
            {
                return -1;
            }
        }

        public float GetValue(Vector3 worldPosition)
        {
            int x, y;
            GetXY(worldPosition, out x, out y);
            return GetValue(x, y);
        }
    }
}