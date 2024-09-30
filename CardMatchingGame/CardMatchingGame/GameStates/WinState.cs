using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using CardMatchingGame;
using Microsoft.Xna.Framework;
using CardMatchingGame.Managers;

namespace CardMatchingGame.GameStates
{
    internal class WinState : GameState
    {
        private static Texture2D _texture;
        private static Microsoft.Xna.Framework.Vector2 _position;
        private static Rectangle _window;
        private static SpriteFont _font;
        private static Microsoft.Xna.Framework.Vector2 _textPosition;
        private static string _text = "";
        public WinState()
        {
            _texture = Globals.Content.Load<Texture2D>("Art/trophy");
            _window = Globals.SpriteBatch.GraphicsDevice.PresentationParameters.Bounds;
            _font = Globals.Content.Load<SpriteFont>("Art/Fonts/score_font");
            _position = new Microsoft.Xna.Framework.Vector2((_window.Width - _texture.Width) / 2, (_window.Height - _texture.Height) / 2);
        }
        public override void Update(GameManager gameManager)
        {
            if (InputManager.MouseClicked)
            {
                gameManager.Restart();
            }
            _text = Math.Round(ScoreManager.Score).ToString();
            var sizeScoreText = _font.MeasureString(_text);
            _textPosition = new Microsoft.Xna.Framework.Vector2((_window.Width-sizeScoreText.X)/2,_position.Y+(_texture.Height/4));
        }
        public override void Draw(GameManager gameManager)
        {
            Globals.SpriteBatch.Draw(_texture, _position, Color.White);
            Globals.SpriteBatch.DrawString(_font,_text,_textPosition, Color.Black);
        }
    }
}
