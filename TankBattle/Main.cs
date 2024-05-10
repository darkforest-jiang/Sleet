using TankBattle.Base;

namespace TankBattle
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        Game _game;

        private void Main_Shown(object sender, EventArgs e)
        {
            _game = new Game(30, this.CreateGraphics(), 1000, 500);

            EntityBase tank = new EntityBase(1);
            tank.AddComponent(World.GetSingletonInput());
            tank.AddComponent(new TransformComponent(new Point(100, 100), new Size(20, 20)));
            tank.AddComponent(new MoveComponent(DfDirections.Right, 50, 50));
            tank.AddComponent(new SpriteComponent(Color.Yellow, 20, 20));
            _game._world.AddEntity(tank);

            EntityBase tank1 = new EntityBase(2);
            tank1.AddComponent(World.GetSingletonInput());
            tank1.AddComponent(new TransformComponent(new Point(100, 400), new Size(20, 20)));
            tank1.AddComponent(new MoveComponent(DfDirections.Right, 50, 100));
            tank1.AddComponent(new SpriteComponent(Color.Red, 20, 20));
            _game._world.AddEntity(tank1);

            _game._world.AddSystem(new MoveSystem(_game._world));
            _game._world.AddSystem(new RenderSystem(_game._world));

            _game.Start();
        }
    }
}