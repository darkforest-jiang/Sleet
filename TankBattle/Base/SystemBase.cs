using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TankBattle.Base;

public class SystemBase
{
    public World _world { get; private set; }
    protected List<Type> _componentTypes = new List<Type>();

    public SystemBase(World world)
    {
        _world = world;
    }

    public virtual void Update()
    {

    }

    public void Subscribe<T>() where T : ComponentBase
    {
        _componentTypes.Add(typeof(T));
    }
    public void Unsubscribe<T>() where T : ComponentBase
    {
        _componentTypes.Remove(typeof(T));
    }

    public bool IsMatch(EntityBase entity)
    {
        foreach(var type in _componentTypes)
        {
            if(!entity.IsHaveComponentType(type))
            {
                return false;
            }
        }
        return true;
    }

}
