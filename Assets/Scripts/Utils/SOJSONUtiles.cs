using System.IO;
using UnityEngine;

namespace DarkCloudGame
{
    [CreateAssetMenu(menuName = "Scriptable Objects / JSON Utils", fileName = "JSON Utils")]
    public class SOJSONUtiles : ScriptableObject
    {
        string filePath;


        private void OnEnable()
        {
            filePath = Application.dataPath + Path.AltDirectorySeparatorChar + "GameData.json";
        }

        public void SaveGameData(float playerHealth, int playerMoves)
        {
            GameData gameData = new GameData(playerHealth, playerMoves);

            string jsonGameDataString = JsonUtility.ToJson(gameData);

            using StreamWriter writer = new StreamWriter(filePath);
            writer.Write(jsonGameDataString);
        }

        public void LoadGameData()
        {
            using StreamReader reader = new StreamReader(filePath);
            string json = reader.ReadToEnd();

            GameData gameData = JsonUtility.FromJson<GameData>(json);

        }
       
    }


    [System.Serializable]
    public class GameData 
    {
        public float playerHealth;
        public int playerMoves;

        public GameData(float playerHealth, int playerMoves)
        {
            this.playerHealth = playerHealth;
            this.playerMoves = playerMoves;

        }
    }
}
