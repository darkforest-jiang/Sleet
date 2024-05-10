﻿using System;
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
        Subscribe<InputComponent>();
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

        transformCop._position = transformCop._position.Move(moveCop._direction, length);
    }
}