using Snake.Enams;
using Snake.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake.Models.Figures
{
    public class Line : Figure 
    {
        public Line(int x, int y, int length, char symbol, LineType type)
        {
            InitPoints(x, y, length, symbol, type);
        }

        private void InitPoints(int x, int y, int length, char symbol, LineType type)
        {
            switch (type)
            {
                case LineType.Vertical:
                    while (y <= length)
                    {
                        _points.Add(new Point(x, y++, symbol));
                    }
                    break;

                case LineType.Horizontal:
                    while (x <= length)
                    {
                        _points.Add(new Point(x++, y, symbol));
                    }
                    break;                
            }
        }
    }
}
