using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TankBattle.Base;

namespace TankBattle;

public class MoveComponent : ComponentBase
{
    public DfDirections _direction { get; set; }
    public int _baseSpeed { get; set; }
    public int _speed { get; set; }

    public bool _isAutoMove { get; set; }

    public MoveComponent(DfDirections direction, int baseSpeed, int speed, bool isAutoMove = true)
    {
        _direction = direction;
        _baseSpeed = baseSpeed;
        _speed = speed;
        _isAutoMove = isAutoMove;
    }

}
