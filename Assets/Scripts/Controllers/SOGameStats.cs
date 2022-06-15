using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DarkCloudGame
{    
    [CreateAssetMenu(menuName = "Scriptable Objects / Game Stats", fileName = "Game Stats")]
    public class SOGameStats : ScriptableObject
    {
        public bool isGamePaused = false;
    }
}
