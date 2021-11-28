using SnakeApp.Enams;

namespace SnakeApp.Models
{
    public class GameSettings
    {
        public string PlayerNick { get; set; }

        public MapType? SelectedMapType { get; set; }
    }
}
