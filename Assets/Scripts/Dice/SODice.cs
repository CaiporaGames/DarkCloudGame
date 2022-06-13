using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DarkCloudGame
{
    [CreateAssetMenu(menuName = "Scriptable Objects / Dice", fileName = "Dice")]
    public class SODice : ScriptableObject
    {
        public int diceValue;

        public void DiceValue()
        {
            diceValue = Random.Range(0, 7);
        }
    }
}
