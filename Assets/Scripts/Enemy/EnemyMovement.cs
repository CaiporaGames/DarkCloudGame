using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DarkCloudGame
{
    public class EnemyMovement : MonoBehaviour
    {
        [SerializeField] LayerMask slimeMask;
        [SerializeField] SOLevelParameters levelParameters;
        float perc = 0;
        float time = 0;
        float maxTime = 0.5f;
        int direction;
        int[] sign = new int[] { -1, 1 };
        Vector3 newPosition;

        void Start()
        {
            StartCoroutine(Timer());           
        }

        void EnemyMove()
        {
            StartCoroutine(Timer());
            if (Random.value < 0.05f)
            {
                direction = Random.Range(0,2);
                newPosition = (Vector3.up * direction + Vector3.left * (1 - direction)) * sign[Random.Range(0, 2)];

                RaycastHit2D hit = RayCastUtils.CalculateRaycast(transform.position, newPosition, 1, slimeMask);
                Debug.DrawRay(transform.position, newPosition, Color.red,2);
                if (!hit.collider 
                    && transform.position.y + newPosition.y < levelParameters.grid.GridOriginPosition.y + levelParameters.grid.Height
                    && transform.position.y + newPosition.y >= levelParameters.grid.GridOriginPosition.y
                    && transform.position.x + newPosition.x < levelParameters.grid.GridOriginPosition.x + levelParameters.grid.Width
                    && transform.position.x + newPosition.x >= levelParameters.grid.GridOriginPosition.x)
                {
                    transform.Translate(newPosition);
                }                
            }
        }

        IEnumerator Timer()
        {
            while (perc < 1)
            {
                yield return null;
                time += Time.deltaTime;
                perc = time / maxTime;
            }

            time = 0;
            perc = 0;
            EnemyMove();
        }
       
    }
}
