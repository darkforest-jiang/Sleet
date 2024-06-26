﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace TankBattle.Base;

public class World
{
    public Game _game { get; private set; }
    public Graphics _graphics { get; private set; }
    private List<SystemBase> _systems = new List<SystemBase> { };
    public Dictionary<int, EntityBase> _entitys = new Dictionary<int, EntityBase> { };

    private static InputComponent _inputComponent;
    public static InputComponent GetSingletonInput()
    {
        return _inputComponent;
    }

    public World(Game game, Graphics graphics) 
    {
        _game = game;
        _graphics = graphics;
        _inputComponent = new InputComponent();
    }

    public void Update()
    {
        foreach(var item in _systems)
        {
            item.Update();
        }
    }

    public void AddSystem(SystemBase system)
    {
        _systems.Add(system);
    }

    public void AddEntity(EntityBase entity)
    {
        _entitys.Add(entity.ID, entity);
    }
    public void RemoveEntity(EntityBase entity)
    {
        _entitys.Remove(entity.ID);
    }

    public int GetNextId()
    {
        if(_entitys.Any())
        {
            return _entitys.Keys.Max() + 1;
        }
        return 1;
    }
}
