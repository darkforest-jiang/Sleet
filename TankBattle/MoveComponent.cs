using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TankBattle.Base;

namespace TankBattle;

public class MoveComponent : ComponentBase
{
    public DfDirections _direction { get; private set; }
    private int _baseSpeed;
    public int _speed { get; private set; }

    public MoveComponent(DfDirections direction, int baseSpeed, int speed)
    {
        _direction = direction;
        _baseSpeed = baseSpeed;
        _speed = speed;
    }

}
