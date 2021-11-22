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
        private int height = 19;
        private int width = 56;

        private int buttonHeight = 2;
        private int butonWidth = 46;

        private int startButtonY = 5;

        public void Print()
        {
            var upWall = new Line(0, 0, width+1, "-", LineType.Horizontal);
            var downWall = new Line(0, height, width+1, "-", LineType.Horizontal);

            var leftWall = new Line(0, 1, height-1, "|", LineType.Vertical);
            var rightWall = new Line(width, 1, height-1, "|", LineType.Vertical);

            upWall.Draw();
            downWall.Draw();
            leftWall.Draw();
            rightWall.Draw();

            var titleDivider = new Line(1, 3, width-1, "-", LineType.Horizontal);
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
            Console.Write($"Ник: НИК"); //ДЗ, в каком классе хранить и брать игрока.
        }

        public void PrintButton(int num, string text)
        {
            int y = (num - 1) * buttonHeight + startButtonY;
            int x = 5;

            var upWall = new Line(x, y, butonWidth + 1, "-", LineType.Horizontal);
            var downWall = new Line(x, y + buttonHeight, butonWidth + 1, "-", LineType.Horizontal);

            var leftWall = new Line(x, y + 1, buttonHeight - 1, "|", LineType.Vertical);
            var rightWall = new Line(x + butonWidth, y + 1, buttonHeight - 1, "|", LineType.Vertical);

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
                //case 4 ДЗ

                case 5:
                    Environment.Exit(0);
                    break;                
            }
        }
    }
}
