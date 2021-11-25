using SnakeApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeApp.Infrastructure
{
    public abstract class GameObject : IGameObject
    {
        protected List<IPoint> _points;
        protected ConsoleColor _color;

        public GameObject(ConsoleColor color)
        {
            _points = new List<IPoint>();
            _color = color;
        }
        
        public void Draw()
        {
            Console.ForegroundColor = _color;

            foreach (var point in _points)
            {
                point.Draw();
            }

            Console.ResetColor();
        }

        public void Delete()
        {
            foreach (var point in _points)
            {
                point.Delete();
            }
        }
        
        public bool IsHit(IPoint inputPoint)
        {            
            return _points.Any(x => x.IsHit(inputPoint));
        }
        
        public bool IsHit(IGameObject figure)
        {
            return _points.Any(x => figure.IsHit(x));
        }
    }
}
