using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake_Game
{
    public class GameState
    {
        public int Rows { get; set; }
        public int Cols { get; set; }
        public GridValue[,] Grid { get; set; }
        public Direction Dir { get; private set; }
        public int Score { get; set; }
        public bool IsGameOver { get; set; }

        private readonly LinkedList<Direction> DirChanges = new LinkedList<Direction>();
        private readonly LinkedList<Position> SnakePosition = new LinkedList<Position>();
        private readonly Random random = new Random();

        public GameState(int _Rows,int _Cols)
        {
            Rows = _Rows;
            Cols = _Cols;
            Grid = new GridValue[Rows, Cols];
            Dir = Direction.Right;
            AddSnake();
            AddFood();
        }
        private void AddSnake()
        {
            int r = Rows / 2;
            for(int c = 1; c <= 3; c++)
            {
                Grid[r, c] = GridValue.Snake;
                SnakePosition.AddFirst(new Position(r, c));
            }
        }
        private IEnumerable<Position> EmptyPosition()
        {
            
            for(int r = 0; r < Rows; r++)
            {
                for(int c = 0; c < Cols; c++)
                {
                    if (Grid[r,c] == GridValue.Empty)
                    {
                        yield return new Position(r, c);
                    }
                }
            }
        }
        private void AddFood()
        {
            
            List<Position> Empty = new List<Position>(EmptyPosition());
            if (Empty.Count == 0)
            {
                return;
            }
            Position pos = Empty[random.Next(Empty.Count)];
            Grid[pos.Row,pos.Col] = GridValue.Food;
        }
        public Position HeadPosition()
        {
            return SnakePosition.First.Value;
        }
        public Position TailPosition()
        {
            return SnakePosition.Last.Value;
        }
        public IEnumerable<Position> SnakePositions()
        {
            return SnakePosition;
        }
        private void AddHead(Position pos)
        {
            SnakePosition.AddFirst(pos);
            Grid[pos.Row, pos.Col] = GridValue.Snake;
        }
        private void RemoveTail()
        {
            Position Tail = SnakePosition.Last.Value;
            Grid[Tail.Row, Tail.Col] = GridValue.Empty;
            SnakePosition.RemoveLast();
        }

        private Direction GetLastDirection()
        {
            if(DirChanges.Count == 0)
            {
                return Dir;
            }
            else
            {
                return DirChanges.Last.Value;
            }
        }
        private bool CanChangeDirection(Direction NewDir)
        {
            if(DirChanges.Count == 2)
            {
                return false;
            }
            Direction LastDir = GetLastDirection();
            return NewDir != LastDir && NewDir != LastDir.Opposite();
        }
        public void ChangeDirection(Direction _Dir)
        {
            //Dir = _Dir;
            if (CanChangeDirection(_Dir))
            {
                DirChanges.AddLast(_Dir);
            }
        }
        private bool OutsideGrid(Position pos)
        {
            return pos.Row <0 || pos.Row >= Rows || pos.Col < 0 || pos.Col >= Cols;
        }
        private GridValue WillHit(Position newHeadPos)
        {
            if (OutsideGrid(newHeadPos))
            {
                return GridValue.Outside;

            }
            if(newHeadPos == TailPosition())
            {
                return GridValue.Empty;
            }

            return Grid[newHeadPos.Row, newHeadPos.Col];

        }
        public void Move()
        {
            if (DirChanges.Count > 0)
            {
                Dir = DirChanges.First.Value;
                DirChanges.RemoveFirst();
            }

            Position NewHeadPos = HeadPosition().Translate(Dir);
            GridValue hit = WillHit(NewHeadPos);
            if(hit == GridValue.Outside || hit == GridValue.Snake)
            {
                IsGameOver = true;
            }
            else if(hit == GridValue.Empty)
            {
                RemoveTail();
                AddHead(NewHeadPos);

            }
            else if(hit == GridValue.Food)
            {
                AddHead(NewHeadPos);
                Score++;
                AddFood();
            }

        }
    }
}
