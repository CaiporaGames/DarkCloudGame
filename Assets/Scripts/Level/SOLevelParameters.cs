using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DarkCloudGame
{
    [CreateAssetMenu(menuName = "Scriptable Objects / Level Parameters", fileName = "Level Parameters")]
    public class SOLevelParameters : ScriptableObject
    {
        public Color[] cellColor;
    }
}
