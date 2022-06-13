using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DarkCloudGame
{
    public class EnemyAnimatorType : MonoBehaviour
    {
        [SerializeField] SOEnemyStats enemyStats;
        [SerializeField] Animator animator;
        // Start is called before the first frame update
        void Start()
        {
            animator.runtimeAnimatorController = enemyStats.runtimeAnimator;
        }       
    }
}
