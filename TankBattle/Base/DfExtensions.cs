using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TankBattle.Base;

public static class DfExtensions
{
    public static Point Move(this Point point, DfDirections direction, int length)
    {
        int x = point.X;
        int y = point.Y;
        switch (direction)
        {
            case DfDirections.Right:
                x += length;
                break;
            case DfDirections.Left:
                x -= length;
                break;
            case DfDirections.Up:
                y -= length;
                break;
            case DfDirections.Down:
                y += length;
                break;
        }
        return new Point(x, y);
    }
}
