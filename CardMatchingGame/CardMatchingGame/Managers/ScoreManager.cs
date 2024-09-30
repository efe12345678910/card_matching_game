using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using CardMatchingGame;

namespace CardMatchingGame.Managers
{
    internal static class ScoreManager
    {
        private const float FIRST_ROUND_TIME = 20;
        private static readonly int _screenWidth;
        private static float _turnTime;
        public static float TurnTimeLeft { get; private set; }
        private static readonly Texture2D _texture;
        private static Rectangle _rectangle;
        public static float Score { get; private set; }
        private static bool _isActive;
        static ScoreManager()
        {
            _turnTime = FIRST_ROUND_TIME;
            TurnTimeLeft = _turnTime;
            _isActive = false;
            _texture = new Texture2D(Globals.SpriteBatch.GraphicsDevice, 1, 1);
            _texture.SetData(new Color[] { new Color(200, 80, 30) });
            _screenWidth = Globals.SpriteBatch.GraphicsDevice.PresentationParameters.BackBufferWidth;
            _rectangle = new Rectangle(0, 0, _screenWidth, 20);
        }
        public static void Start()
        {
            _isActive = true;
        }
        public static void Stop()
        {
            _isActive = false;
        }
        public static void Reset()
        {
            _turnTime = FIRST_ROUND_TIME;
            TurnTimeLeft = _turnTime;
            Score = 0;
            _isActive = false;
            _rectangle.Width = _screenWidth;
        }
        public static void NextTurn()
        {
            Score += 10 * TurnTimeLeft;
            _turnTime--;
            TurnTimeLeft = _turnTime;
        }
        public static void Miss()
        {
            Score -= 10;
        }
        public static void Update()
        {
            if (!_isActive) return;
            TurnTimeLeft -= Globals.Time;
            _rectangle.Width = (int)(_screenWidth * TurnTimeLeft / _turnTime);
        }
        public static void Draw()
        {
            Globals.SpriteBatch.Draw(_texture, _rectangle, null, Color.White, 0, Vector2.Zero, SpriteEffects.None, 1);
        }

    }
}
