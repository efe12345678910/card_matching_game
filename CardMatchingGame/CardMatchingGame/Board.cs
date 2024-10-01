using CardMatchingGame.Managers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;

namespace CardMatchingGame
{
    internal class Board
    {
        private const int CARDS_PER_DIM = 4;
        private const int CARD_SPACING = 10;
        public List<Card> Cards { get; } = new List<Card>();
        public int CardsLeft { get; private set; }
        public Board()
        {
            var back = Globals.Content.Load<Texture2D>("Art/Cards/card_back");
            var window = Globals.SpriteBatch.GraphicsDevice.PresentationParameters.Bounds;
            Point cardDistance = new Point(back.Width+CARD_SPACING,back.Height+CARD_SPACING);
            Point boardSize = new Point((cardDistance.X*CARDS_PER_DIM)-CARD_SPACING,(cardDistance.Y*CARDS_PER_DIM)-CARD_SPACING);
            Point boardSpacing = new Point((window.Width-boardSize.X+back.Width)/2,(window.Height-boardSize.Y+back.Height)/2);
            const int CARD_COUNT = CARDS_PER_DIM * CARDS_PER_DIM;
            CardsLeft = Cards.Count;
            Texture2D[] textureFrontArray = new Texture2D[CARD_COUNT / 2];
            for (int j = 0; j < CARD_COUNT / 2; j++)
            {
                textureFrontArray[j] = Globals.Content.Load<Texture2D>($"Art/Cards/cards_front/{j+1}");
            }
            for (int i = 0; i < CARD_COUNT; i++)
            {
                var x = (cardDistance.X*(i%CARDS_PER_DIM) + boardSpacing.X);
                var y = (cardDistance.Y * (i / CARDS_PER_DIM) + boardSpacing.Y);
                Cards.Add(new Card(i/2,back, textureFrontArray[i/2],new Vector2(x,y)));
            }
            Shuffle();
        }
        public void Shuffle()
        {
            Random random = new Random();
            for (int i = Cards.Count - 1; i > 0; i--)
            {
                int j = random.Next(i+1);
                (Cards[j].CardPosition, Cards[i].CardPosition) = (Cards[i].CardPosition, Cards[j].CardPosition);
            }
        }
        public void Collect(Card c1, Card c2)
        {
            c1.Visible = false;
            c2.Visible = false;
            CardsLeft -= 2;
        }
        public void ResetBoard()
        {
            CardsLeft = CARDS_PER_DIM*CARDS_PER_DIM;
            foreach (Card card in Cards)
            {
                card.Reset();
            }
            Shuffle();
        }
        public Card GetClickedCard()
        {
            
            if (!InputManager.MouseClicked) return null;
            foreach (Card card in Cards)
            {
                if(!card.Visible || card.IsFlipping) continue;
                if(card.CardRectangle.Intersects(InputManager.MouseRectangle)) return card;
            }
            return null;
        }
        public void Draw()
        {
            foreach (var card in Cards)
            {
                card.Draw();
            }
        }
        public void Update()
        {
            foreach (Card card in Cards)
            {
                card.Update();
            }
        }
    }
}
