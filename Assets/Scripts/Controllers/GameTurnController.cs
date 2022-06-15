using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


namespace DarkCloudGame
{
    public class GameTurnController : MonoBehaviour
    {

        [SerializeField] GameObject messageCanvas;
        [SerializeField] GameObject diceButtonGO;
        [SerializeField] Button playerAttackButton;


        bool canPlayerAttack = false;
        bool runOnce = true;
        Color attackButtonColor;
        Color diceButtonColor;
        Button diceButton;
        int playerMovements = 0;
        GameObject selectedEnemy;
        float perc = 0, time = 0, maxTime = 5;

        public static GameTurnController _instance;
        public static GameTurnController Instance { get { return _instance; } }
        public bool CanPlayerAttack { get { return canPlayerAttack; } set { canPlayerAttack = value; } }
        public int PlayerMovements { get { return playerMovements; } }


        public delegate void ReducePlayerMovementsCount();
        public static ReducePlayerMovementsCount reducePlayerMovementsCount;

        private void Awake()
        {
            if (_instance != this && _instance != null)
            {
                Destroy(gameObject);
            }
            else
            {
                _instance = this;
            }
        }

       
        private void Start()
        {
            canPlayerAttack = true;
            attackButtonColor = playerAttackButton.GetComponent<Image>().color;
            diceButtonColor = diceButtonGO.GetComponent<RawImage>().color;
            diceButton = diceButtonGO.GetComponent<Button>();
            playerMovements = Random.Range(0, 7);
            reducePlayerMovementsCount?.Invoke();
        }


        private void Update()
        {
            ControlGameTurn();
        }


        void ControlGameTurn()
        {
            if (canPlayerAttack)
            {
                messageCanvas.SetActive(true);
                playerAttackButton.interactable = true;
                attackButtonColor = new Vector4(1,1,1,1);
                diceButton.interactable = true;
                diceButtonColor = new Vector4(1, 1, 1, 1);
            }
            else
            {
                messageCanvas.SetActive(false);
                playerAttackButton.interactable = false;
                attackButtonColor = new Vector4(1, 1, 1, 0.5f);
                diceButton.interactable = false;
                diceButtonColor = new Vector4(1, 1, 1, 0.5f);
                if (runOnce)
                {
                    runOnce = false;
                    StartCoroutine(Timer());
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

            SelectEnemyToAttackPlayer();

            time = 0;
            perc = 0;
        }
        

        void SelectEnemyToAttackPlayer()
        {
            //Select enemy
            int random = Random.Range(0, SEnemiesHolder.Instance.Enemies.Count);
            selectedEnemy = SEnemiesHolder.Instance.Enemies[random];

            //call the attack method from the enemy
            selectedEnemy.GetComponent<EnemyAttack>().Attack();
            canPlayerAttack = true;
            runOnce = true;

        }

        public void Dice()
        {
            canPlayerAttack = false;
            playerMovements = Random.Range(0,7);
            reducePlayerMovementsCount?.Invoke();

        }

        public void ReducePlayerMovements()
        {
            if (playerMovements <= 0)
            {
                return;
            }
            playerMovements--;
            reducePlayerMovementsCount?.Invoke();
        }       
    }
}
