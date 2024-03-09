using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime;
using System.Text;
using System.Threading.Tasks;

namespace Snake_Game
{
    public class Position
    {
        public int Row { get; set; }
        public int Col { get; set; }

        public Position(int _Row,int _Col)
        {
            Row = _Row;
            Col = _Col;
        }
        public Position Translate(Direction direction)
        {
            return new Position(Row + direction.RowOffset, Col + direction.ColOffset);
        }

        public override bool Equals(object obj)
        {
            return obj is Position position &&
                   Row == position.Row &&
                   Col == position.Col;
        }

        public override int GetHashCode()
        {
            int hashCode = 1084646500;
            hashCode = hashCode * -1521134295 + Row.GetHashCode();
            hashCode = hashCode * -1521134295 + Col.GetHashCode();
            return hashCode;
        }

        public static bool operator ==(Position left, Position right)
        {
            return EqualityComparer<Position>.Default.Equals(left, right);
        }

        public static bool operator !=(Position left, Position right)
        {
            return !(left == right);
        }
    }
}
