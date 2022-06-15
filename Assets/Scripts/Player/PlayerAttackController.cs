using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DarkCloudGame
{
    public class PlayerAttackController : MonoBehaviour
    {
        [SerializeField] GameObject attackPrefabEffect;

        Vector3 attackDirection;
        float perc = 0, time = 0, maxTime = 4;


        private void OnEnable()
        {
            PlayerSelectAttackPoint.playerSelectAttackPoint += Attack;
        }


        public void AttackButton()//This is the button that the player press on screen
        {           
            GameTurnController.Instance.CanPlayerAttack = false;
            StartCoroutine(Timer());
        }

        void Attack(Vector3 targetPosition)//Player select point on grid
        {
            attackPrefabEffect.transform.position = transform.position;
            attackDirection =  targetPosition - transform.position;
        }

        IEnumerator Timer()
        {
            attackPrefabEffect.SetActive(true);

            while (perc < 1)
            {
                yield return null;
                attackPrefabEffect.transform.Translate(attackDirection * Time.deltaTime * 0.5f);
                time += Time.deltaTime;
                perc = time / maxTime;
            }

            attackPrefabEffect.SetActive(false);
            attackPrefabEffect.transform.position = transform.position;
            time = 0;
            perc = 0;
        }

        private void OnDisable()
        {
            PlayerSelectAttackPoint.playerSelectAttackPoint -= Attack;
        }

    }
}
