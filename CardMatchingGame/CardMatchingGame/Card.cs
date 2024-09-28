using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardMatchingGame
{
    internal class Card
    {
        private readonly Texture2D _textureBack;
        public Vector2 CardPosition { get; set; }
        public Card(Texture2D textureBack, Vector2 position)
        {
            _textureBack = textureBack;
            CardPosition = position;
        }
        public void Draw()
        {
            Globals.SpriteBatch.Draw(_textureBack,CardPosition,Color.White);
        }
    }
}
