using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DarkCloudGame
{
    public class TileData : MonoBehaviour
    {
        [SerializeField]
        Vector3 tileWorldPosition;
        [SerializeField]
        float tileValue;


        public Vector3 TileWorldPosition { set { tileWorldPosition = value; } }
        public float TileValue { set { tileValue = value; } }

    }
}
