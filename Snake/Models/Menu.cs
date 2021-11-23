using SnakeApp.Enams;
using SnakeApp.Models.Figures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeApp.Models
{
    public class Menu
    {
        private int height = 22;
        private int width = 60;

        private int buttonHeight = 2;
        private int butonWidth = 50;

        private int startButtonY = 7;
        private readonly Game _game;

        public Menu(Game game)
        {
            _game = game;
        }

        public void Print()
        {
            Console.SetWindowSize(61, 30);
            Console.Clear();

            var upWall = new Line(0, 0, width+1, "-", LineType.Horizontal, ConsoleColor.Yellow);
            var downWall = new Line(0, height, width+1, "-", LineType.Horizontal, ConsoleColor.Yellow);

            var leftWall = new Line(0, 1, height-1, "|", LineType.Vertical, ConsoleColor.Yellow);
            var rightWall = new Line(width, 1, height-1, "|", LineType.Vertical, ConsoleColor.Yellow);

            upWall.Draw();
            downWall.Draw();
            leftWall.Draw();
            rightWall.Draw();

            var titleDivider = new Line(1, 3, width-1, "-", LineType.Horizontal, ConsoleColor.Yellow);
            titleDivider.Draw();

            Console.SetCursorPosition(24, 1);
            Console.Write("ЗМЕЙКА");
            Console.SetCursorPosition(21, 2);
            Console.Write("Главное меню");

            PrintButton(1, "Играть");
            PrintButton(2, "Смена ника");
            PrintButton(3, "Выбор карты");
            PrintButton(4, "Таблица рейтинга");
            PrintButton(5, "Выход");

            int yNick = 5 * buttonHeight + startButtonY + 2;
            int xNick = 5;

            Console.SetCursorPosition(xNick, yNick);
            Console.Write($"Ник: {_game.CurentPlayer.Name}");

            Console.SetCursorPosition(xNick, yNick + 1);
            Console.Write($"Очки: {_game.CurentPlayer.Points}");            

            string selectedMap = "Выбранная карта: ";

            if (_game.SelectedMapType == MapType.Box)
            {
                selectedMap += "карта со стенами";
            }
            else
            {
                selectedMap += "карта без стен";
            }

            Console.SetCursorPosition(xNick, startButtonY - 2);
            Console.Write(selectedMap);

        }

        public void PrintButton(int num, string text)
        {
            int y = (num - 1) * buttonHeight + startButtonY;
            int x = 5;

            var upWall = new Line(x, y, butonWidth + 1, "-", LineType.Horizontal, ConsoleColor.DarkYellow);
            var downWall = new Line(x, y + buttonHeight, butonWidth + 1, "-", LineType.Horizontal, ConsoleColor.DarkYellow);

            var leftWall = new Line(x, y + 1, buttonHeight - 1, "|", LineType.Vertical, ConsoleColor.DarkYellow);
            var rightWall = new Line(x + butonWidth, y + 1, buttonHeight - 1, "|", LineType.Vertical, ConsoleColor.DarkYellow);

            upWall.Draw();
            downWall.Draw();
            leftWall.Draw();
            rightWall.Draw();

            Console.SetCursorPosition(x + butonWidth / 2 - 6, y + buttonHeight / 2);
            Console.WriteLine($"{num}. {text}");
        }

        public static string GetDivider(int num)
        {
            StringBuilder stringBuilder = new StringBuilder();

            for (int i = 0; i < num; i++)
            {
                stringBuilder.Append('-');
            }

            return stringBuilder.ToString();
        }

        public void ScanMenuItem()
        {
            Console.SetCursorPosition(0, height + 2);
            Console.Write("Введите пункт меню: ");
            int menuItem = int.Parse(Console.ReadLine());

            switch (menuItem)
            {
                case 1:
                    _game.Play();
                    break;

                case 2:
                    Console.Write("Введите ник:");
                    string nickname = Console.ReadLine();
                    _game.ChangePlayerNickname(nickname);

                    break;

                case 3:
                    SelectMapType();
                    break;

                case 4:
                    ShowLeaderBoard();                   
                    break;

                case 5:
                    Environment.Exit(0);
                    break;                
            }
        }

        private void SelectMapType()
        {
            string maps = 
                "1. Карта со стенами\n" +
                "2. Карта без стен";

            Console.WriteLine("Выберете карту из списка ниже:");
            Console.WriteLine(maps);

            Console.Write("Введите номер карты: ");
            int numMap = int.Parse(Console.ReadLine());

            switch (numMap)
            {
                case 1:
                    _game.SelectedMapType = MapType.Box;
                    break;

                case 2:
                    _game.SelectedMapType = MapType.Empty;
                    break;
            }

        }

        private void ShowLeaderBoard()
        {
            _game.LeaderBoard.Print();

            Console.Write("\nДля того что бы вернуться в меню, нажмите любую клавишу: ");
            Console.ReadKey();
        }
    }
}
