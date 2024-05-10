using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TankBattle.Base;

public class Game
{
    private int _fps;
    private Graphics _graphics;
    private Bitmap _dfBmp;
    private Graphics _graphicsBmp;
    public World _world { get; private set; }

    public Game(int fps, Graphics graphics, int width, int height)
    {
        _fps = fps;
        _graphics = graphics;

        _dfBmp = new Bitmap(width, height);
        _graphicsBmp = Graphics.FromImage(_dfBmp);

        _world = new World(_graphicsBmp);
        DfTimer._deltaTime = 1000 / _fps;
    }

    public void Start()
    {
        Task.Factory.StartNew(() => {

            while(true)
            {
                _world.Update();

                _graphics.DrawImage(_dfBmp, 0, 0);
                _graphicsBmp.Clear(Color.Black);

                Thread.Sleep((int)DfTimer._deltaTime);
            }
            
        });
    }
}
