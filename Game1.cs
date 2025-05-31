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
        private Texture2D _texture, _addButton, _subButton, _modeButton, _run, _chronometer;

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

            //Idea to make the textures work. It worked! But I do not know
            //why I need to load the textures twice - in Game1, and in the class.

            _addButton = Content.Load<Texture2D>("addButton");
            _subButton = Content.Load<Texture2D>("subButton");
            _modeButton = Content.Load<Texture2D>("modeButton");
            _run = Content.Load<Texture2D>("notRunning");
            _chronometer = Content.Load<Texture2D>("chronometer");


            //Instantiating two timer objects.
            _timer1 = new Timer(new Vector2(100, 100), new Vector2(180, 189), _font, Content.Load<Texture2D>("Clock"), 40, false, true);
            _timer2 = new Timer(new Vector2(400, 100), new Vector2(480, 189), _font, Content.Load<Texture2D>("Clock"), 120, false, true);

            //Ask why of this.
            _timer1.LoadContent(Content);
            _timer2.LoadContent(Content);


            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // Updating my objects.

            _timer1.Update(gameTime);
            _timer2.Update(gameTime);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.DarkSlateGray);

            // Drawing my objects.

            _timer1.Draw(_spriteBatch);
            _timer2.Draw(_spriteBatch);

            //Calling accessors to show that everything works fine.
            _spriteBatch.Begin();

            //Information about Timer1
            _spriteBatch.DrawString(_font, "Timer: " + _timer1.GetSetTimer(), _timer1.GetLocation() + new Vector2(20, 220), Color.Black);
            _spriteBatch.DrawString(_font, "Running?: " + _timer1.GetIsRunning(), _timer1.GetLocation() + new Vector2(20, 250), Color.Black);
            _spriteBatch.DrawString(_font, "Countdown: " + _timer1.GetCountdown(), _timer1.GetLocation() + new Vector2(20, 280), Color.Black);


            //Information about Timer2
            _spriteBatch.DrawString(_font, "Timer: " + _timer2.GetSetTimer(), _timer2.GetLocation() + new Vector2(20, 220), Color.DarkGoldenrod);
            _spriteBatch.DrawString(_font, "Running?: " + _timer2.GetIsRunning(), _timer2.GetLocation() + new Vector2(20, 250), Color.DarkGoldenrod);
            _spriteBatch.DrawString(_font, "Countdown: " + _timer2.GetCountdown(), _timer2.GetLocation() + new Vector2(20, 280), Color.DarkGoldenrod);

            _spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
