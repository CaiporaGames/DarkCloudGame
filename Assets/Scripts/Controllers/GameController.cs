using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


namespace DarkCloudGame
{
    public class GameController : MonoBehaviour
    {

        [SerializeField] GameObject messagePanel;
        [SerializeField] Button playerAttackButton;


        bool canPlayerAttack = false;
        Color buttonColor;
        int playerMovements = 0;

        public static GameController _instance;
        public static GameController Instance { get { return _instance; } }
        public bool CanPlayerAttack { get { return canPlayerAttack; } set { canPlayerAttack = value; } }
        public int PlayerMovements { get { return playerMovements; } }

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

        private void OnEnable()
        {
            PlayerMovement.playerValidMovement += ReducePlayerMovements;
        }


        private void Start()
        {
            canPlayerAttack = true;
            buttonColor = playerAttackButton.GetComponent<Image>().color;
            playerMovements = Random.Range(0, 7);
            PlayerMovement.playerValidMovement?.Invoke();
        }


        private void Update()
        {
            Debug.Log(playerMovements);
            ControlGameTurn();
        }


        void ControlGameTurn()
        {
            if (canPlayerAttack)
            {
                messagePanel.SetActive(true);
                playerAttackButton.interactable = true;
                buttonColor = new Vector4(1,1,1,1);

            }
            else
            {
                SelectEnemyToAttackPlayer();
                messagePanel.SetActive(false);
                playerAttackButton.interactable = false;
                buttonColor = new Vector4(1, 1, 1, 0.5f);
            }
        }
        

        void SelectEnemyToAttackPlayer()
        {
            //Select enemy

            //call the attack method from the enemy
        }

        public void Dice()
        {
            PlayerMovement.playerValidMovement?.Invoke();
            canPlayerAttack = false;
            playerMovements = Random.Range(0,7);
        }

        void ReducePlayerMovements()
        {
            playerMovements--;
        }

        private void OnDisable()
        {
            PlayerMovement.playerValidMovement -= ReducePlayerMovements;
        }
    }
}
