using System.IO;
using UnityEngine;

namespace DarkCloudGame
{
    [CreateAssetMenu(menuName = "Scriptable Objects / JSON Utils", fileName = "JSON Utils")]
    public class SOJSONUtiles : ScriptableObject//Basic save system with save and load methods.
    {
        string filePath;
        GameData gameData;

        private void OnEnable()
        {
            filePath = Application.dataPath + Path.AltDirectorySeparatorChar + "GameData.json";
            gameData = new GameData(100, 4);
        }

        public void SaveGameData(float playerHealth, int playerMoves)
        {
            GameData gameData = new GameData(playerHealth, playerMoves);

            string jsonGameDataString = JsonUtility.ToJson(gameData);

            using StreamWriter writer = new StreamWriter(filePath);
            writer.Write(jsonGameDataString);
        }

        public GameData LoadGameData()
        {
            if (File.Exists(filePath))
            {
                using StreamReader reader = new StreamReader(filePath);
                string json = reader.ReadToEnd();

                gameData = JsonUtility.FromJson<GameData>(json);
            }

            return gameData;
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
