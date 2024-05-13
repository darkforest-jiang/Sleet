using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TankBattle.Base;

namespace TankBattle;

public class FireComponent : ComponentBase
{
    public int _fireInterval { get; set; }
    public int _speed { get; set; }

    public Size _size { get; set; }
    public Color _color { get; set; }

    public DateTime? _lastFireTime { get; set; }

    public FireComponent(int fireInterval, int speed, Size size, Color color)
    {
        _fireInterval = fireInterval;
        _speed = speed;
        _size = size;
        _color = color;
    }

}
