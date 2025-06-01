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
        private int _setTimer, _currentTime;
        private bool _isRunning, _countdown;
        private Vector2 _location, _textLocation, _addLocation, _subLocation, _modeLocation, _runningLocation, _chronometerLocation;
        private Texture2D _texture, _addButton, _subButton, _modeButton, _run, _chronometer;
        private SpriteFont _clockFont;
        private float _addX, _addY, _subX, _subY, _modeX, _modeY;

        //Trying to apply real time.
        private TimeSpan _time;


        //Here are my constructors.
        public Timer(Vector2 location, Vector2 textLocation, SpriteFont font,Texture2D texture, int setTimer, bool isRunning, bool countdown)
        {
            _location = location;
            _textLocation = textLocation;
            _clockFont = font;
            _texture = texture;
            _time = TimeSpan.Zero;

            //Code to manually positionate the buttons. This will make the textures
            //get printed in the right position, no matter how many times I instantiate the object.
            _addLocation = new Vector2(149, 95);
            _subLocation = new Vector2(31, 95);
            _modeLocation = new Vector2(80, 130);
            _runningLocation = new Vector2(0, 0);
            _chronometerLocation = new Vector2(0, 0);

            _setTimer = setTimer;
            _currentTime = setTimer;
            _isRunning = isRunning;
            _countdown = countdown;


            //Adding a limit to prevent the timer goes to extreme values.
            if (_setTimer < 60)
                _setTimer = 60;
            else if (_setTimer > 300)
                _setTimer = 300;
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

        public Vector2 GetLocation()
        {
            return _location;
        }


        //Here are my mutator methods. Updated to prevent _setTimer goes below 60 and higher than 300 seconds.
        public void Add()
        {
            _setTimer += 60;
            if (_setTimer > 300)
                _setTimer = 300;
        }

        public void Subtract()
        {
            _setTimer -= 60;
            if (_setTimer < 60)
                _setTimer = 60;
        }

        public void Mode()
        {
            if (_countdown == true)
                _countdown = false;
            else
                _countdown = true;
        }

        //Mutator responsible to modify _currentTime according to the timer's mode.
        //Also, _time = TimeSpan.Zero; Makes the timer starts from 0, no matter how long it takes me to press space.
        public void Run()
        {
            _isRunning = true;
            _time = TimeSpan.Zero;

            if (_countdown == true)
                _currentTime = _setTimer;
            else
                _currentTime = 0;
        }


        //This is my loadContent. I think this could work to add textures and print properly the buttons.
        public void LoadContent(ContentManager content)
        {
            _addButton = content.Load<Texture2D>("addButton");
            _subButton = content.Load<Texture2D>("subButton");
            _modeButton = content.Load<Texture2D>("modeButton");
            _run = content.Load<Texture2D>("notRunning");
            _chronometer = content.Load<Texture2D>("chronometer");
        }

        //Update. Making it works in seconds instead of frames.
        //_time -= TimeSpan.FromSeconds(1); Helps me to subtract 1 once _time reaches 1. That way, it always work from 0 to 1.

        public void Update(GameTime gameTime)
        {
            _time += gameTime.ElapsedGameTime;

            if (_time.TotalSeconds >= 1)
            {
                _time -= TimeSpan.FromSeconds(1);

                if (Keyboard.GetState().IsKeyDown(Keys.Space))
                    this.Run();

                if (_isRunning == true && _countdown == true)
                {
                    _currentTime--;

                    if (_currentTime <= 0)
                        _isRunning = false;

                }

                if (_isRunning == true && _countdown == false)
                {
                    _currentTime++;
                    if (_currentTime == _setTimer)
                        _isRunning = false;
                }


                //Creating hitbox rectangle for the buttons. Perfectly working!
                Rectangle _addHitbox = new Rectangle((int)(_location.X + _addLocation.X), (int)(_location.Y + _addLocation.Y), _addButton.Width, _addButton.Height);
                Rectangle _subHitbox = new Rectangle((int)(_location.X + _subLocation.X), (int)(_location.Y + _subLocation.Y), _subButton.Width, _subButton.Height);
                Rectangle _modeHitbox = new Rectangle((int)(_location.X + _modeLocation.X), (int)(_location.Y + _modeLocation.Y), _modeButton.Width, _modeButton.Height);

                //Making buttons work with mouse.
                MouseState currentMouseState = Mouse.GetState();
                if (currentMouseState.LeftButton == ButtonState.Pressed)
                {
                    if (_addHitbox.Contains(currentMouseState.Position))
                        this.Add();
                    if (_subHitbox.Contains(currentMouseState.Position))
                        this.Subtract();
                    if (_modeHitbox.Contains(currentMouseState.Position))
                        this.Mode();

                }
            }

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            spriteBatch.Draw(_texture, _location, Color.White);

            //Printing strings according to the mode of the timer. Also changing from white to red if it is running or not.
            if (_isRunning == true)
                spriteBatch.DrawString(_clockFont, _currentTime + "", _textLocation, Color.Red);
            else
            {
                spriteBatch.DrawString(_clockFont, _setTimer + "", _textLocation, Color.White);
                spriteBatch.Draw(_run, _location + _runningLocation, Color.White);
            }
                
            if (_countdown == false)
                spriteBatch.Draw(_chronometer, _location + _chronometerLocation, Color.White);

            //Now printing buttons!
            spriteBatch.Draw(_addButton, _location + _addLocation, Color.White);
            spriteBatch.Draw(_subButton, _location + _subLocation, Color.White);
            spriteBatch.Draw(_modeButton, _location + _modeLocation, Color.White);

            spriteBatch.End();
        }


    }


}
