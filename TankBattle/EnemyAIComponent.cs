using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TankBattle.Base;

namespace TankBattle;

public class EnemyAIComponent : ComponentBase
{
    public int _excuteInterval { get; private set; }
    public DateTime? _lastExcuteTime { get; set; }

    public EnemyAIComponent(int excuteInterval)
    {
        _excuteInterval = excuteInterval;
    }

}
