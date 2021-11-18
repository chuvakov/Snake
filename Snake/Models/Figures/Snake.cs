using SnakeApp.Enams;
using SnakeApp.Infrastructure;
using System;
using System.Linq;

namespace SnakeApp.Models.Figures
{
    //TODO: везде в методах добавить комменты (///); запрограммировать метод MOVE (без циклов);
    public class Snake : Figure, ISnake
    {
        private IPoint _head;
        private IPoint _tail;

        private MoveDirection _direction;

        public Snake(IPoint tail, int length, MoveDirection direction)
        {
            _tail = tail;
            _direction = direction;

            Init(length);
        }

        /// <summary>
        /// Инициализация змейки
        /// </summary>        
        private void Init(int length)
        {
            _points.Add(_tail);

            for (int i = 1; i < length; i++)
            {
                IPoint point = (IPoint)_points.Last().Clone();
                point.Move(_direction, 1);
                _points.Add(point);
            }

            _head = _points.Last();
        }

        /// <summary>
        /// Движение змейки
        /// </summary>        
        public void Move()
        {
            DeleteTail();
            AddHead();

            _head.Draw();
        }

        /// <summary>
        /// Добавление головы
        /// </summary>        
        private void AddHead()
        {
            _head = (IPoint)_points.Last().Clone();
            _head.Move(_direction, 1);
            _points.Add(_head);
        }

        /// <summary>
        /// Удаление хвоста
        /// </summary>
        private void DeleteTail()
        {
            _points.Remove(_tail);
            _tail.Delete();
            _tail = _points[0];
        }

        public void HandleKey(ConsoleKey key)
        {
            switch (key)
            {
                case ConsoleKey.LeftArrow:
                    if (_direction == MoveDirection.Right)
                    {
                        return;
                    }
                    _direction = MoveDirection.Left;
                    break;

                case ConsoleKey.UpArrow:
                    if (_direction == MoveDirection.Down)
                    {
                        return;
                    }
                    _direction = MoveDirection.Up;
                    break;

                case ConsoleKey.RightArrow:
                    if (_direction == MoveDirection.Left)
                    {
                        return;
                    }
                    _direction = MoveDirection.Right;
                    break;

                case ConsoleKey.DownArrow:
                    if (_direction == MoveDirection.Up)
                    {
                        return;
                    }
                    _direction = MoveDirection.Down;
                    break;
            }
        }

        public bool IsHitTail()
        {
            IPoint nextHead = GetNextHead();

            return IsHit(nextHead);
        }

        /// <summary>
        /// Получаем следующую голову
        /// </summary>        
        private IPoint GetNextHead()
        {
            IPoint nextHead = (IPoint)_head.Clone();
            nextHead.Move(_direction, 1);
            return nextHead;
        }

        public bool EatFood(IPoint food)
        {
            IPoint nextHead = GetNextHead();

            if (nextHead.IsHit(food))
            {
                food.Symbol = nextHead.Symbol;

                _points.Add(food);

                return true;
            }

            return false;
        }

    }
}
