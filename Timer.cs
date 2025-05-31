using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace GME1011_A2_BastV
{
    internal class Timer
    {

        //Here I declare my attributes.
        private GraphicsDeviceManager _graphics;
        private int _setTimer, _currentTime;
        private bool _isRunning, _countdown;
        private Vector2 _location, _textLocation;
        private Texture2D _texture, _addButton, _subButton, _modeButton, _run;
        private SpriteFont _clockFont;
        private float _addX, _addY, _subX, _subY, _modeX, _modeY;


        //Here are my constructors. Now encapsulated.
        public Timer(Vector2 location, Vector2 textLocation, SpriteFont font,Texture2D texture, int setTimer, bool isRunning, bool countdown)
        {
            _location = location;
            _textLocation = textLocation;
            _clockFont = font;
            _texture = texture;

            _setTimer = 120;
            _currentTime = setTimer;
            _isRunning = isRunning;
            _countdown = countdown;

            if (_setTimer < 60)
                setTimer = 60;
            else
                _setTimer = setTimer;

            if (_setTimer > 300)
                setTimer = 300;
            else
                _setTimer = setTimer;
        }


        //Here are my accessor methods.
        public int GetSetTimer()
        {
            return _setTimer;
        }

        public int GetCurrentTime()
        {
            return _currentTime;
        }

        public bool GetIsRunning()
        {
            return _isRunning;
        }

        public bool GetCountdown()
        {
            return _countdown;
        }


        //Here are my mutator methods.
        public void Add()
        {
            _setTimer += 60;
        }

        public void Subtract()
        {
            _setTimer -= 60;
        }


        //This is my loadContent. I think this could work to add textures and print properly the buttons.
        public void LoadContent(ContentManager content)
        {
            _addButton = content.Load<Texture2D>("addButton");
            _subButton = content.Load<Texture2D>("subButton");
            _modeButton = content.Load<Texture2D>("modeButton");
            _run = content.Load<Texture2D>("notRunning");
        }

        //This is my idea of how update could work.

        public void Update(GameTime gameTime)
        {

            if (Keyboard.GetState().IsKeyDown(Keys.Space))
                _isRunning = true;

            if (_isRunning == true && _countdown == true)
            {
                for (_currentTime = _setTimer; _currentTime > 0; _currentTime--)
                    _isRunning = false;
            }
                

            else if (_isRunning == true && _countdown == false)
            {
                for (_currentTime = 0; _currentTime < _setTimer; _currentTime++)
                    _isRunning = false;
            }

            //Measuring my three buttons sprites. Add, Subtract, and Mode.

            _addX = MathHelper.Clamp(_addX, 0, _graphics.PreferredBackBufferWidth - _addButton.Width);
            _addY = MathHelper.Clamp(_addY, 0, _graphics.PreferredBackBufferHeight - _addButton.Height);
            _subX = MathHelper.Clamp(_subX, 0, _graphics.PreferredBackBufferWidth - _subButton.Width);
            _subY = MathHelper.Clamp(_subY, 0, _graphics.PreferredBackBufferHeight - _subButton.Height);
            _modeX = MathHelper.Clamp(_modeX, 0, _graphics.PreferredBackBufferWidth - _modeButton.Width);
            _modeY = MathHelper.Clamp(_modeY, 0, _graphics.PreferredBackBufferHeight - _modeButton.Height);

            //Creating hitbox rectangle for the buttons
            Rectangle _addHitbox = new Rectangle((int)_addX, (int)_addY, _addButton.Width, _addButton.Height);
            Rectangle _subHitbox = new Rectangle((int)_subX, (int)_subY, _subButton.Width, _subButton.Height);
            Rectangle _modeHitbox = new Rectangle((int)_modeX, (int)_modeY, _modeButton.Width, _modeButton.Height);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            spriteBatch.Draw(_texture, _location, Color.White);

            spriteBatch.DrawString(_clockFont, _setTimer + "", _textLocation, Color.White);
            if (_isRunning == true)
                spriteBatch.DrawString(_clockFont, _currentTime + "", _textLocation, Color.Red);
            else
                spriteBatch.DrawString(_clockFont, _currentTime + "", _textLocation, Color.White);
                spriteBatch.Draw(_run, _location, Color.White);

            spriteBatch.End();
        }


    }


}
