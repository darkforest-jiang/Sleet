using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TankBattle.Base;

namespace TankBattle;

public class EnemyAISystem : SystemBase
{
    private Random _random = new Random(Guid.NewGuid().GetHashCode());

    public EnemyAISystem(World world) : base(world)
    {
        Subscribe<TransformComponent>();
        Subscribe<MoveComponent>();
        Subscribe<FireComponent>();
        Subscribe<EnemyAIComponent>();
        Subscribe<SpriteComponent>();
    }

    public override void Update()
    {
        for (int index = 0; index < _world._entitys.Count; index++)
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

        var transformCop = entity.GetComponent<TransformComponent>()!;
        var moveCop = entity.GetComponent<MoveComponent>()!;
        var fireCop = entity.GetComponent<FireComponent>()!;
        var enemyCop = entity.GetComponent<EnemyAIComponent>()!;
        var spriteCop = entity.GetComponent<SpriteComponent>()!;

        if(enemyCop._lastExcuteTime != null)
        {
            var ts = nowDt - enemyCop._lastExcuteTime.Value;
            if(ts.TotalMilliseconds  >= enemyCop._excuteInterval)
            {
                //改变方向
                var nextDirection = (DfDirections)_random.Next(0, 4);
                moveCop._direction = nextDirection;
                //改变颜色贴图
                Color color = Color.YellowGreen;
                switch (nextDirection)
                {
                    case DfDirections.Left:
                        color = Color.Pink;
                        break;
                    case DfDirections.Up:
                        color = Color.Blue;
                        break;
                    case DfDirections.Down:
                        color = Color.SandyBrown;
                        break;
                }
                spriteCop.SetTexture(color, transformCop._size.Width, transformCop._size.Height);

                //是否发射子弹
                var isFire = _random.Next(0, 2);
                if(isFire == 1)
                {
                    bool isCanFire;
                    if (fireCop._lastFireTime == null)
                    {
                        isCanFire = true;
                    }
                    else
                    {
                        var tsFire = nowDt - fireCop._lastFireTime.Value;
                        isCanFire = ts.TotalSeconds >= 2;
                    }
                    if (isCanFire)
                    {
                        var bullet = new EntityBase(_world.GetNextId());
                        int x = 0, y = 0;
                        switch (moveCop._direction)
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
                        bullet.AddComponent(new MoveComponent(moveCop._direction, fireCop._speed, fireCop._speed, true));
                        bullet.AddComponent(new SpriteComponent(fireCop._color, fireCop._size.Width, fireCop._size.Height));
                        _world.AddEntity(bullet);
                        fireCop._lastFireTime = nowDt;
                    }
                }

                enemyCop._lastExcuteTime = DateTime.Now;
            }
        }
        else
        {
            enemyCop._lastExcuteTime = DateTime.Now;
        }

    }

}
