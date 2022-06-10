using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DarkCloudGame
{

    [CreateAssetMenu(menuName = "Scriptable Objects / Player Stats", fileName = "Player Stats")]
    public class SOPlayerStats : ScriptableObject
    {
        public string playerName;
        public float playerHealth;
        public float playerAttack;
    }
}

