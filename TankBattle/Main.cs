using System.Xml.Linq;
using TankBattle.Base;

namespace TankBattle
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw, true);
        }

        Game _game;

        private void Main_Shown(object sender, EventArgs e)
        {
            _game = new Game(30, this.CreateGraphics(), 800, 400);
            _game._getPressKey = () => {
                return _pressKey;
            };

            EntityBase enemy = new EntityBase(1);
            enemy.AddComponent(World.GetSingletonInput());
            enemy.AddComponent(new TransformComponent(new Point(100, 100), new Size(20, 20)));
            enemy.AddComponent(new MoveComponent(DfDirections.Right, 50, 50));
            enemy.AddComponent(new EnemyAIComponent(2000));
            enemy.AddComponent(new SpriteComponent(Color.Yellow, 20, 20));
            _game._world.AddEntity(enemy);

            EntityBase enemy2 = new EntityBase(2);
            enemy2.AddComponent(World.GetSingletonInput());
            enemy2.AddComponent(new TransformComponent(new Point(200, 100), new Size(50, 50)));
            enemy2.AddComponent(new MoveComponent(DfDirections.Right, 50, 100));
            enemy2.AddComponent(new EnemyAIComponent(2000));
            enemy2.AddComponent(new SpriteComponent(Color.DarkOrange, 50, 50));
            _game._world.AddEntity(enemy2);

            EntityBase enemy3 = new EntityBase(3);
            enemy3.AddComponent(World.GetSingletonInput());
            enemy3.AddComponent(new TransformComponent(new Point(300, 400), new Size(20, 20)));
            enemy3.AddComponent(new MoveComponent(DfDirections.Right, 50, 80));
            enemy3.AddComponent(new EnemyAIComponent(2000));
            enemy3.AddComponent(new SpriteComponent(Color.PeachPuff, 20, 20));
            _game._world.AddEntity(enemy3);

            EntityBase tank1 = new EntityBase(100);
            tank1.AddComponent(World.GetSingletonInput());
            tank1.AddComponent(new TransformComponent(new Point(100, 400), new Size(20, 20)));
            tank1.AddComponent(new MoveComponent(DfDirections.Right, 50, 0, false));
            tank1.AddComponent(new PlayerComponet());
            tank1.AddComponent(new SpriteComponent(Color.Red, 20, 20));
            _game._world.AddEntity(tank1);

            _game._world.AddSystem(new PlayerSystem(_game._world));
            _game._world.AddSystem(new EnemyAISystem(_game._world));
            _game._world.AddSystem(new MoveSystem(_game._world));
            _game._world.AddSystem(new RenderSystem(_game._world));

            _game.Start();
        }

        private DfKeys? _pressKey;
        private void Main_KeyDown(object sender, KeyEventArgs e)
        {
            _pressKey = new DfKeys(e.KeyCode, e.Control);
        }

        private void Main_KeyUp(object sender, KeyEventArgs e)
        {
            _pressKey = null;
        }
    }
}