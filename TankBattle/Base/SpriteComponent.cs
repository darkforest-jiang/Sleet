using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TankBattle.Base;

public class SpriteComponent : ComponentBase
{
    public Bitmap _texture { get; private set; }

    public SpriteComponent(Bitmap texture)
    {
        _texture = texture;
    }

    public SpriteComponent(Color color, int width, int height)
    {
        SetTexture(color, width, height);
    }

    public void SetTexture(Color color, int width, int height)
    {
        _texture = new Bitmap(width, height);
        using var g = Graphics.FromImage(_texture);
        g.Clear(color);
    }
}
