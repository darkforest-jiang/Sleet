using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TankBattle.Base;

namespace TankBattle;

public class RenderSystem : SystemBase
{
    public RenderSystem(World world) : base(world)
    {
        Subscribe<TransformComponent>();
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

    private void Excute(EntityBase entity)
    {
        var transformCop = entity.GetComponent<TransformComponent>()!;
        var spriteCop = entity.GetComponent<SpriteComponent>()!;

        _world._graphics.DrawImage(spriteCop._texture, transformCop._position);
    }

}
