using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TankBattle.Base;

namespace TankBattle;

public class TransformComponent : ComponentBase
{
    public Point _position { get; set; }

    public Size _size { get; set; }

    public TransformComponent(Point position, Size size)
    {
        _position = position;
        _size = size;
    }
}
