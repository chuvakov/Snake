using SnakeApp.Enams;
using SnakeApp.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeApp.Models.Figures
{
    public class Line : GameObject 
    {
        public Line(int x, int y, int length, string symbol, LineType type, ConsoleColor color) 
            : base(color)
        {
            InitPoints(x, y, length, symbol, type);
        }
        
        private void InitPoints(int x, int y, int length, string symbol, LineType type)
        {
            switch (type)
            {
                case LineType.Vertical:
                    for (int i = 0; i < length; i++)
                    {
                        _points.Add(new Point(x, y++, symbol, _color));
                    }
                    break;

                case LineType.Horizontal:
                    for (int i = 0; i < length; i++)
                    {                          
                        _points.Add(new Point(x++, y, symbol, _color));
                    }
                    break;                
            }
        }
    }
}
