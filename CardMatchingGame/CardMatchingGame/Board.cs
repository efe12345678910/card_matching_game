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
        private const int BOARD_PADDING = 50;
        public List<Card> Cards { get; } = new List<Card>();
        public Board()
        {
            var back = Globals.Content.Load<Texture2D>("Art/Cards/card_back");
            var cardDistance = back.Width+CARD_SPACING;
            const int CARD_COUNT = CARDS_PER_DIM * CARDS_PER_DIM;
            Texture2D[] textureFrontArray = new Texture2D[CARD_COUNT / 2];
            for (int j = 0; j < CARD_COUNT / 2; j++)
            {
                textureFrontArray[j] = Globals.Content.Load<Texture2D>($"Art/Cards/cards_front/{j+1}");
            }
            for (int i = 0; i < CARD_COUNT; i++)
            {
                var x = (cardDistance*(i%CARDS_PER_DIM) + BOARD_PADDING);
                var y = (cardDistance * (i / CARDS_PER_DIM) + BOARD_PADDING);
                Cards.Add(new Card(back, textureFrontArray[i/2],new Vector2(x,y)));
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
        public Card GetClickedCard()
        {
            if (!InputManager.MouseClicked) return null;
            foreach (Card card in Cards)
            {
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
    }
}
