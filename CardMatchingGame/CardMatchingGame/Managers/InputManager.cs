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
        public static Rectangle MouseRectangle { get; private set; }
        public static void Update()
        {
            //This also ensures that the motion is triggered once per click rather than multiple times
            MouseClicked = Mouse.GetState().LeftButton == ButtonState.Pressed 
                && _lastMouseState.LeftButton == ButtonState.Released;
            _lastMouseState = Mouse.GetState();
            MouseRectangle = new Rectangle(_lastMouseState.X,_lastMouseState.Y,1,1);
            
        }
    }
}
