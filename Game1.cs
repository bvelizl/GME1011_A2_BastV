using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace GME1011_A2_BastV
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private Timer _timer1, _timer2;
        private SpriteFont _font;
        private Texture2D _texture;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            _font = Content.Load<SpriteFont>("font");

            _timer1 = new Timer(new Vector2(100, 100), new Vector2(180, 189), _font, Content.Load<Texture2D>("Clock"), 120, false, true);
            _timer2 = new Timer(new Vector2(400, 100), new Vector2(480, 189), _font, Content.Load<Texture2D>("Clock"), 120, false, true);

            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            _timer1.Update(gameTime);
            _timer2.Update(gameTime);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here

            _timer1.Draw(_spriteBatch);
            _timer2.Draw(_spriteBatch);

            base.Draw(gameTime);
        }
    }
}
