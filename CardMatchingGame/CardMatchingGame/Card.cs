using CardMatchingGame.Managers;
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
        public bool IsCardFlipped { get; private set; }
        public int ID { get; }
        public bool Visible { get; set; }
        public Rectangle CardRectangle => new Rectangle((int)CardPosition.X, (int)CardPosition.Y,_activeTexture.Width,_activeTexture.Height);
        public Vector2 CardPosition { get; set; }
        public Card(int id,Texture2D textureBack,Texture2D textureFront, Vector2 position)
        {
            ID = id;
            _textureBack = textureBack;
            _textureFront = textureFront;
            CardPosition = position;
            _activeTexture = _textureBack;
            Visible = true;
        }
        
        public void Flip()
        {
            IsCardFlipped = !IsCardFlipped;
            _activeTexture = IsCardFlipped ? _textureFront : _textureBack;
        }
        
        public void Draw()
        {
            if (Visible)
            {
                Globals.SpriteBatch.Draw(_activeTexture, CardPosition, Color.White);
            }
        }
    }
}
