using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DarkCloudGame
{
    public class TileData : MonoBehaviour
    {
        [SerializeField] SOPlayerStats playerStats;
        [SerializeField] SOLevelParameters levelParameters;

        Vector3 tileWorldPosition;
        float tileValue;
        float tileDefaultGroundValue;
        bool hasAnotherElement = false;
        Collider2D _collider;
        SpriteRenderer spriteRenderer;

       

        private void Start()
        {
            if (tileValue == 3 || tileValue == 2)
            {
                _collider = GetComponent<Collider2D>();
                spriteRenderer = GetComponent<SpriteRenderer>();
                _collider.enabled = true;
            }
        }


        public Vector3 TileWorldPosition { set { tileWorldPosition = value; } }
        public float TileValue { set { tileValue = value; } }
        public float TileDefaultGroundValue { set { tileDefaultGroundValue = value; } }
        public bool HasAnotherElement { set { hasAnotherElement = value; } }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (tileValue == 3 && playerStats.playerHealth < playerStats.maxHealth)
            {
                playerStats.playerHealth = playerStats.SetupPlayerHealth(-10);
                spriteRenderer.color = levelParameters.cellColor[(int)tileDefaultGroundValue];
                _collider.enabled = false;
            }
        }      

    }
}
