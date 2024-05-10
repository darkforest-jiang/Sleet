using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TankBattle.Base;

public class EntityBase
{
    public int ID { get; private set; }
    protected Dictionary<Type, ComponentBase> _components = new Dictionary<Type, ComponentBase>();

    public EntityBase(int id)
    {
        this.ID = id;
    }

    public void AddComponent<T>(T component) where T : ComponentBase
    {
        _components[typeof(T)] = component;
    }
    public T? GetComponent<T>() where T : ComponentBase
    {
        ComponentBase? component = null;
        _components.TryGetValue(typeof(T), out component);
        return component as T;
    }
    public bool IsHaveComponentType(Type componentType)
    {
        return _components.ContainsKey(componentType);
    }
    public void RemoveComponent<T>() where T : ComponentBase
    {
        _components.Remove(typeof(T));
    }
}
