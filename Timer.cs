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


        //Here is my argumented constructor.
        public Timer(int setTimer, bool countdown)
        {
            _setTimer = 120;
            _currentTime = 120;
            _isRunning = false;
            _countdown = false;
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
    }


}
