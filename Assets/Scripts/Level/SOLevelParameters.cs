using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DarkCloudGame
{
    [CreateAssetMenu(menuName = "Scriptable Objects / Level Parameters", fileName = "Level Parameters")]
    public class SOLevelParameters : ScriptableObject//Should have more variables when the game get more robust
    {
        public Color[] cellColor;
        public float[,] gridArrayValues;
        public Vector3[,] gridWorldPositions;

        public Grid grid;
        public void CreateGrid(int width, int height, float cellSize, Vector3 gridOriginPosition)
        {
            grid = new Grid(width, height, cellSize, gridOriginPosition);
            gridArrayValues = grid.GridArrayValues;
            gridWorldPositions = grid.GridWorldPositions;

        }
    }
}
