using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TankBattle.Base;

public class InputComponent : ComponentBase
{
    public DfKeys? _pressKey { get; private set; }
    public void SetPressKey(DfKeys? pressKey)
    {
        _pressKey = pressKey;
    }
}
