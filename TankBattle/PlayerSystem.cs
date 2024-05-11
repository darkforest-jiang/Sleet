using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TankBattle.Base;

namespace TankBattle;

public class PlayerSystem : SystemBase
{
    public PlayerSystem(World world) : base(world)
    {
        Subscribe<InputComponent>();
        Subscribe<MoveComponent>();
        Subscribe<PlayerComponet>();
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
        var inputCop = entity.GetComponent<InputComponent>()!;
        var movCop = entity.GetComponent<MoveComponent>()!;

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
        }
    }

}
