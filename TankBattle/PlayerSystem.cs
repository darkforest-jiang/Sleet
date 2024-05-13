using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using TankBattle.Base;

namespace TankBattle;

public class PlayerSystem : SystemBase
{
    public PlayerSystem(World world) : base(world)
    {
        Subscribe<InputComponent>();
        Subscribe<TransformComponent>();
        Subscribe<MoveComponent>();
        Subscribe<PlayerComponet>();
        Subscribe<FireComponent>();
    }

    public override void Update()
    {
        for (int index = 0; index < _world._entitys.Count; index ++)
        {
            var item = _world._entitys.Skip(index).First();
            if (IsMatch(item.Value))
            {
                Excute(item.Value);
            }
        }
    }

    public void Excute(EntityBase entity)
    {
        var nowDt = DateTime.Now;

        var inputCop = entity.GetComponent<InputComponent>()!;
        var movCop = entity.GetComponent<MoveComponent>()!;
        var transformCop = entity.GetComponent<TransformComponent>()!;
        var fireCop = entity.GetComponent<FireComponent>()!;

        if(inputCop._pressKey == null)
        {
            return;
        }

        switch(inputCop._pressKey.Value._pressKey)
        {
            case Keys.Right:
                movCop._direction = DfDirections.Right;
                movCop._speed = movCop._baseSpeed;
                break;
            case Keys.Left:
                movCop._direction = DfDirections.Left;
                movCop._speed = movCop._baseSpeed;
                break;
            case Keys.Up:
                movCop._direction = DfDirections.Up;
                movCop._speed = movCop._baseSpeed;
                break;
            case Keys.Down:
                movCop._direction = DfDirections.Down;
                movCop._speed = movCop._baseSpeed;
                break;
            case Keys.J://发射子弹
                bool isCanFire;
                if(fireCop._lastFireTime == null)
                {
                    isCanFire = true;
                }
                else
                {
                    var ts = nowDt - fireCop._lastFireTime.Value;
                    isCanFire = ts.TotalSeconds >= 2;
                }
                if(isCanFire)
                {
                    var bullet = new EntityBase(_world.GetNextId());
                    int x = 0, y = 0;
                    switch(movCop._direction)
                    {
                        case DfDirections.Right:
                            x = transformCop._position.X + transformCop._size.Width;
                            y = transformCop._position.Y + (transformCop._size.Height / 2 - fireCop._size.Width / 2);
                            break;
                        case DfDirections.Left:
                            x = transformCop._position.X - fireCop._size.Width;
                            y = transformCop._position.Y + (transformCop._size.Height / 2 - fireCop._size.Width / 2);
                            break;
                        case DfDirections.Up:
                            x = transformCop._position.X + (transformCop._size.Width / 2 - fireCop._size.Width / 2);
                            y = transformCop._position.Y - fireCop._size.Width;
                            break;
                        case DfDirections.Down:
                            x = transformCop._position.X + (transformCop._size.Width / 2 - fireCop._size.Width / 2);
                            y = transformCop._position.Y + transformCop._size.Height;
                            break;
                    }
                    bullet.AddComponent(new TransformComponent(
                        new Point(x, y), fireCop._size
                    ));
                    bullet.AddComponent(new MoveComponent(movCop._direction, fireCop._speed, fireCop._speed, true));
                    bullet.AddComponent(new SpriteComponent(fireCop._color, fireCop._size.Width, fireCop._size.Height));
                    _world.AddEntity(bullet);
                    fireCop._lastFireTime = nowDt;
                }
                break;
        }
    }

}
