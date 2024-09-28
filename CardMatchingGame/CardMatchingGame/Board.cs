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
            var back = Globals.Content.Load<Texture2D>("Cards/card_back");
            var cardDistance = back.Width+CARD_SPACING;
            const int _cardCount = CARDS_PER_DIM * CARDS_PER_DIM;
            for (int i = 0; i < _cardCount; i++)
            {
                var x = (cardDistance*(i%CARDS_PER_DIM) + BOARD_PADDING);
                var y = (cardDistance * (i / CARDS_PER_DIM) + BOARD_PADDING);
                Cards.Add(new Card(back,new Vector2(x,y)));
            }
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
