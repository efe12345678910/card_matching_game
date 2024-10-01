using CardMatchingGame.Managers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
        private Vector2 _origin;
        private Vector2 _scale;
        public Rectangle CardRectangle => new Rectangle((int)(CardPosition.X-_origin.X), (int)(CardPosition.Y-_origin.Y),_activeTexture.Width,_activeTexture.Height);
        public Vector2 CardPosition { get; set; }
        private readonly float _flipTime;
        private float _flipTimeLeft;
        public bool IsFlipping { get; private set; }
        private int _flippingDirection;
        public Card(int id,Texture2D textureBack,Texture2D textureFront, Vector2 position)
        {
            ID = id;
            _textureBack = textureBack;
            _textureFront = textureFront;
            CardPosition = position;
            _activeTexture = _textureBack;
            Visible = true;
            _origin = new(_textureBack.Width/2, _textureBack.Height/2);
            _scale = Vector2.One;
            _flipTime = 0.1f;
            //Debug.WriteLine($"card ID: {ID}\nCard PositionX: {CardPosition.X}\nRect X: {CardRectangle.X}\nCard Pos Y: {CardPosition.Y}\nRect Y: {CardRectangle.Y}");
            Reset();
        }
        public void Reset()
        {
            _activeTexture = _textureBack;
            Visible = true;
            IsCardFlipped = false;
            IsFlipping = false;
            _scale = Vector2.One;
            _flippingDirection = -1;
            _flipTimeLeft = _flipTime;
        }
        public void Flip()
        {
            IsFlipping = true;
            IsCardFlipped = !IsCardFlipped;
            _flippingDirection = -1;
            _flipTimeLeft = _flipTime;
        }
        
        public void Draw()
        {
            if (Visible)
            {
                Globals.SpriteBatch.Draw(_activeTexture, CardPosition,null, Color.White,0f,_origin,_scale,SpriteEffects.None,1f);
                //var dot = new Texture2D(Globals.SpriteBatch.GraphicsDevice, 1, 1);
                //dot.SetData(new Color[] { new Color(200, 80, 30) });
                //Globals.SpriteBatch.Draw(dot, CardPosition - _origin, null, Color.White, 0f, Vector2.Zero, new Vector2(10, 10), SpriteEffects.None, 1);
            }
        }
        public void Update()
        {
            if (IsFlipping)
            {
                _flipTimeLeft += Globals.Time * _flippingDirection;
                _scale.X = _flipTimeLeft / _flipTime;
                if (_flipTimeLeft <= 0)
                {
                    _flippingDirection = 1;
                    _activeTexture = IsCardFlipped ? _textureFront: _textureBack;
                }
                else if (_flipTimeLeft > _flipTime)
                {
                    _flippingDirection = -1;
                    IsFlipping =false;
                    _scale = Vector2.One;
                }
            }
        }
    }
}
