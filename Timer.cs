using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GME1011_A2_BastV
{
    internal class Timer
    {

        //Here I declare my attributes.
        private int _setTimer, _currentTime;
        private bool _isRunning, _countdown;
        private Vector2 _location;
        private List<Texture2D> _texture;
        private SpriteFont _clockFont;


        //Here is my zero-argument constructor.
        public Timer()
        {
            _setTimer = 120;
            _currentTime = 120;
            _isRunning = false;
            _countdown = false;
        }


        //Here is my argumented constructor. Now encapsulated.
        public Timer(int setTimer, bool countdown)
        {
            if(_setTimer < 60)
                _setTimer = 60;
            else
                _setTimer = setTimer;

            if (_setTimer > 300)
                _setTimer = 300;
            else
                _setTimer = setTimer;

            _currentTime = setTimer;
            _isRunning = false;
            _countdown = countdown;
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

        //This is my idea of how update could work.
        /*
         * protected override void Update(GameTime gameTime.totalGameTime.Seconds)
         * if(_isRunning = true && _countdown = true)
         * _currentTime --;
         * if(_currentTime == 0)
         * _isRunning = false;
         * 
         * if(_isRunning = true && _countdown = false)
         * _currentTime == 0;
         * _currentTime ++;
         * if(_currentTime == _setTimer)
         * _isRunning = false;
         * 
         */
    }


}
