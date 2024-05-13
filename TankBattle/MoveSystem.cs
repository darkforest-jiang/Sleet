using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TankBattle.Base;

namespace TankBattle;

public class MoveSystem : SystemBase
{
    public MoveSystem(World world): base(world)
    {
        Subscribe<TransformComponent>();
        Subscribe<MoveComponent>();
    }

    public override void Update()
    {
        foreach(var item in _world._entitys)
        {
            if(IsMatch(item.Value))
            {
                Excute(item.Value);
            }
        }
    }

    private void Excute(EntityBase entity)
    {
        var moveCop = entity.GetComponent<MoveComponent>()!;
        var transformCop = entity.GetComponent<TransformComponent>()!;

        var length = Convert.ToInt32(moveCop._speed * ((decimal)DfTimer._deltaTime / 1000));

        var nextPosition = transformCop._position.Move(moveCop._direction, length);

        int x = nextPosition.X;
        int y = nextPosition.Y;
        if(x < 0)
        {
            x = 0;
        }
        if(x > _world._game._size.Width - transformCop._size.Width)
        {
            x = _world._game._size.Width - transformCop._size.Width;
        }
        if(y < 0)
        {
            y = 0;
        }
        if(y > _world._game._size.Height - transformCop._size.Height)
        {
            y = _world._game._size.Height - transformCop._size.Height;
        }

        transformCop._position = new Point(x, y);

        if(!moveCop._isAutoMove)
        {
            moveCop._speed = 0;
        }
    }
}
