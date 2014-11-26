using Gengine.Commands;
using Microsoft.Xna.Framework.Input;

namespace Gengine.Input {
    public class InputManager {
        private static readonly InputManager instance = new InputManager();
        private InputManager() { }
        public static InputManager Instance { get { return instance; } }

        private KeyboardState lastKeyBoardState;
        //private MouseState lastMouseState;

        public void HandleInput(CommandQueue commandQueue) {
            commandQueue.Clear();

            KeyboardState currentKeyBoardState = Keyboard.GetState();
            if (lastKeyBoardState.IsKeyDown(Keys.Up) && currentKeyBoardState.IsKeyUp(Keys.Up)) {
                commandQueue.QueueCommand("Up");
            }
            if (lastKeyBoardState.IsKeyDown(Keys.Down) && currentKeyBoardState.IsKeyUp(Keys.Down)) {
                commandQueue.QueueCommand("Down");
            }
            if (lastKeyBoardState.IsKeyDown(Keys.Enter) && currentKeyBoardState.IsKeyUp(Keys.Enter)) {
                commandQueue.QueueCommand("Enter");
            } 
            if (lastKeyBoardState.IsKeyDown(Keys.Escape) && currentKeyBoardState.IsKeyUp(Keys.Escape)) {
                commandQueue.QueueCommand("Escape");
            }
            lastKeyBoardState = currentKeyBoardState;
        }

        public void HandleRealTimeInput(CommandQueue commandQueue) {
            KeyboardState currentKeyBoardState = Keyboard.GetState();

            if (currentKeyBoardState.IsKeyDown(Keys.Left)) {
                commandQueue.QueueCommand("Left");
            }
            if (currentKeyBoardState.IsKeyDown(Keys.Right)) {
                commandQueue.QueueCommand("Right");
            }
            if (currentKeyBoardState.IsKeyDown(Keys.Space)) {
                commandQueue.QueueCommand("Space");
            }
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
