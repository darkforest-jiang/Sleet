using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TankBattle.Base;

public struct DfKeys
{
    public Keys _pressKey { get; private set; }

    public bool _isCtrl { get; private set; } = false;

    public DfKeys(Keys key, bool isCtrl = false)
    {
        _pressKey = key;
        _isCtrl = isCtrl;
    }

}
