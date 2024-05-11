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
        Subscribe<EnemyAIComponent>();
        Subscribe<SpriteComponent>();
    }

    public override void Update()
    {
        foreach (var item in _world._entitys)
        {
            if (IsMatch(item.Value))
            {
                Excute(item.Value);
            }
        }
    }

    public void Excute(EntityBase entity)
    {
        var tansformCop = entity.GetComponent<TransformComponent>()!;
        var MoveCop = entity.GetComponent<MoveComponent>()!;
        var enemyCop = entity.GetComponent<EnemyAIComponent>()!;
        var spriteCop = entity.GetComponent<SpriteComponent>()!;

        if(enemyCop._lastExcuteTime != null)
        {
            var ts = DateTime.Now - enemyCop._lastExcuteTime.Value;
            if(ts.TotalMilliseconds  >= enemyCop._excuteInterval)
            {
                var nextDirection = (DfDirections)_random.Next(0, 4);
                MoveCop._direction = nextDirection;

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
                spriteCop.SetTexture(color, tansformCop._size.Width, tansformCop._size.Height);
                enemyCop._lastExcuteTime = DateTime.Now;
            }
        }
        else
        {
            enemyCop._lastExcuteTime = DateTime.Now;
        }

    }

}
