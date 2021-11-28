using Newtonsoft.Json;
using System.IO;

namespace SnakeApp.Models
{
    public class DataStorage
    {
        private readonly string _pathToStorage;

        private const string _fileNameLeaderBoard = "LeaderBoard.txt";
        private const string _fileNameGameSettings = "GameSettings.txt";

        public DataStorage(string pathToStorage)
        {
            _pathToStorage = pathToStorage;
                        
            Directory.CreateDirectory(pathToStorage);

            if (!File.Exists(Path.Combine(_pathToStorage, _fileNameLeaderBoard)))
            {
                File.Create(Path.Combine(_pathToStorage, _fileNameLeaderBoard)).Dispose();
            }

            if (!File.Exists(Path.Combine(_pathToStorage, _fileNameGameSettings)))
            {
                File.Create(Path.Combine(_pathToStorage, _fileNameGameSettings)).Dispose();
            }
        }

        public void Save(LeaderBoard leaderBoard, GameSettings gameSettings)
        {
            Save(leaderBoard);
            Save(gameSettings);
        }

        public void Save(LeaderBoard leaderBoard)
        {
            using (StreamWriter sw = new StreamWriter(Path.Combine(_pathToStorage, _fileNameLeaderBoard)))
            {
                sw.WriteLine(JsonConvert.SerializeObject(leaderBoard));
            }
        }

        public void Save(GameSettings gameSettings)
        {
            using (StreamWriter sw = new StreamWriter(Path.Combine(_pathToStorage, _fileNameGameSettings)))
            {
                sw.WriteLine(JsonConvert.SerializeObject(gameSettings));
            }
        }        

        public LeaderBoard LoadLeaderBoard()
        {
            LeaderBoard leaderBoard;

            using (StreamReader sr = new StreamReader(Path.Combine(_pathToStorage, _fileNameLeaderBoard)))
            {
                leaderBoard = JsonConvert.DeserializeObject<LeaderBoard>(sr.ReadToEnd());
            }

            return leaderBoard;
        }

        public GameSettings LoadGameSettings()
        {
            GameSettings gameSettings;

            using (StreamReader sr = new StreamReader(Path.Combine(_pathToStorage, _fileNameGameSettings)))
            {
                gameSettings = JsonConvert.DeserializeObject<GameSettings>(sr.ReadToEnd());
            }

            return gameSettings;
        }
    }
}
