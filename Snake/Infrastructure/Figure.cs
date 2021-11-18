using SnakeApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeApp.Infrastructure
{
    public abstract class Figure : IFigure
    {
        protected List<IPoint> _points;

        public Figure()
        {
            _points = new List<IPoint>();
        }
        /// <summary>
        /// отрисовать фигуру
        /// </summary>
        public void Draw()
        {            
            foreach (var point in _points)
            {
                point.Draw();
            }
        }
        /// <summary>
        /// проверка на соприкосновение точки
        /// </summary>
        public bool IsHit(IPoint inputPoint)
        {            
            return _points.Any(x => x.IsHit(inputPoint));
        }
        /// <summary>
        /// проверка на соприкосновение фигуры
        /// </summary>
        public bool IsHit(IFigure figure)
        {
            return _points.Any(x => figure.IsHit(x));
        }
    }
}
