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
        private readonly Texture2D _textureFront;
        private Texture2D _activeTexture;
        private bool _cardIsFlipped;
        public Vector2 CardPosition { get; set; }
        public Card(Texture2D textureBack,Texture2D textureFront, Vector2 position)
        {
            _textureBack = textureBack;
            _textureFront = textureFront;
            CardPosition = position;
            _activeTexture = _textureBack;
            Flip();
        }
        public void Flip()
        {
            _cardIsFlipped = !_cardIsFlipped;
            _activeTexture = _cardIsFlipped ? _textureFront : _textureBack;
        }
        public void Draw()
        {
            Globals.SpriteBatch.Draw(_activeTexture,CardPosition,Color.White);
        }
    }
}
