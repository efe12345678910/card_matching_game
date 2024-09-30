using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardMatchingGame.Managers
{
    public static class InputManager
    {
        private static MouseState _lastMouseState;
        public static bool MouseClicked { get; private set; }
        public static bool MouseRightClicked { get; private set; }
        public static Rectangle MouseRectangle { get; private set; }
        public static void Update()
        {
            var ms = Mouse.GetState();
            bool onScreen = ms.X >= 0 && ms.X < Globals.SpriteBatch.GraphicsDevice.PresentationParameters.BackBufferWidth &&
                ms.Y >= 0 && ms.Y < Globals.SpriteBatch.GraphicsDevice.PresentationParameters.BackBufferHeight;
            //This also ensures that the motion is triggered once per click rather than multiple times
            MouseClicked = Mouse.GetState().LeftButton == ButtonState.Pressed && _lastMouseState.LeftButton == ButtonState.Released && onScreen;
            //same logic with LB. This time for RB.
            MouseRightClicked = Mouse.GetState().RightButton == ButtonState.Pressed && _lastMouseState.RightButton == ButtonState.Released && onScreen;
            MouseRectangle = new Rectangle(_lastMouseState.X,_lastMouseState.Y,1,1);
            _lastMouseState = Mouse.GetState();


        }
    }
}
