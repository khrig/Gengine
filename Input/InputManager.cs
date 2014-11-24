using Microsoft.Xna.Framework.Input;

namespace Gengine.Input {
    public class InputManager {
        private static readonly InputManager instance = new InputManager();
        private InputManager() { }
        public static InputManager Instance { get { return instance; } }

        private KeyboardState lastKeyBoardState;
        //private MouseState lastMouseState;

        public string HandleInput() {
            return HandleKeyPressed();
            //lastMouseState = HandleMouse();
        }

        public string HandleRealTimeInput() {
            string returnKey = string.Empty;
            KeyboardState currentKeyBoardState = Keyboard.GetState();
            if (currentKeyBoardState.IsKeyDown(Keys.Up)) {
                returnKey = "Up";
            }
            if (currentKeyBoardState.IsKeyDown(Keys.Down)) {
                returnKey = "Down";
            }
            if (currentKeyBoardState.IsKeyDown(Keys.Left)) {
                returnKey = "Left";
            }
            if (currentKeyBoardState.IsKeyDown(Keys.Right)) {
                returnKey = "Right";
            }
            return returnKey;
        }

        private string HandleKeyPressed() {
            string returnKey = string.Empty;

            KeyboardState currentKeyBoardState = Keyboard.GetState();
            if (lastKeyBoardState.IsKeyDown(Keys.S) && currentKeyBoardState.IsKeyUp(Keys.S)) {
                returnKey = "S";
            }
            if (lastKeyBoardState.IsKeyDown(Keys.G) && currentKeyBoardState.IsKeyUp(Keys.G)) {
                returnKey = "G";
            }
            if (lastKeyBoardState.IsKeyDown(Keys.Space) && currentKeyBoardState.IsKeyUp(Keys.Space)) {
                returnKey = "Space";
            }
            if (lastKeyBoardState.IsKeyDown(Keys.Up) && currentKeyBoardState.IsKeyUp(Keys.Up)) {
                returnKey = "Up";
            }
            if (lastKeyBoardState.IsKeyDown(Keys.Down) && currentKeyBoardState.IsKeyUp(Keys.Down)) {
                returnKey = "Down";
            }
            if (lastKeyBoardState.IsKeyDown(Keys.Enter) && currentKeyBoardState.IsKeyUp(Keys.Enter)) {
                returnKey = "Enter";
            }
            if (lastKeyBoardState.IsKeyDown(Keys.Escape) && currentKeyBoardState.IsKeyUp(Keys.Escape)) {
                returnKey = "Escape";
            }

            lastKeyBoardState = currentKeyBoardState;

            return returnKey;
        }
        /*
        private MouseState HandleMouse() {
            MouseState currentMouseState = Mouse.GetState();
            if (lastMouseState.LeftButton == ButtonState.Pressed && currentMouseState.LeftButton == ButtonState.Released) {
                currentMouseState.X, currentMouseState.Y
            }
            return currentMouseState;
        }*/
    }
}
