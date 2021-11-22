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

        public GameObject()
        {
            _points = new List<IPoint>();
        }
        
        public void Draw()
        {            
            foreach (var point in _points)
            {
                point.Draw();
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
