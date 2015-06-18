using Gengine.Commands;
using Microsoft.Xna.Framework.Input;

namespace Gengine.Input {
    public class InputManager {
        private static readonly InputManager _instance = new InputManager();
        private InputManager() { }
        public static InputManager Instance { get { return _instance; } }

        private KeyboardState _lastKeyBoardState;
        //private MouseState lastMouseState;

        public void HandleInput(CommandQueue commandQueue, ICommandFactory commandFactory) {
            commandQueue.Clear();

            KeyboardState currentKeyBoardState = Keyboard.GetState();
            if (_lastKeyBoardState.IsKeyDown(Keys.Up) && currentKeyBoardState.IsKeyUp(Keys.Up)) {
                commandQueue.QueueCommand(commandFactory.CreateCommand("Up"));
            }
            if (_lastKeyBoardState.IsKeyDown(Keys.Down) && currentKeyBoardState.IsKeyUp(Keys.Down)) {
                commandQueue.QueueCommand(commandFactory.CreateCommand("Down"));
            }
            if (_lastKeyBoardState.IsKeyDown(Keys.Enter) && currentKeyBoardState.IsKeyUp(Keys.Enter)) {
                commandQueue.QueueCommand(commandFactory.CreateCommand("Enter"));
            } 
            if (_lastKeyBoardState.IsKeyDown(Keys.Escape) && currentKeyBoardState.IsKeyUp(Keys.Escape)) {
                commandQueue.QueueCommand(commandFactory.CreateCommand("Escape"));
            }
            if (_lastKeyBoardState.IsKeyDown(Keys.P) && currentKeyBoardState.IsKeyUp(Keys.P)) {
                commandQueue.QueueCommand(commandFactory.CreateCommand("Pause"));
            }
            if (_lastKeyBoardState.IsKeyDown(Keys.U) && currentKeyBoardState.IsKeyUp(Keys.U)) {
                commandQueue.QueueCommand(commandFactory.CreateCommand("Debug"));
            }
            if (_lastKeyBoardState.IsKeyDown(Keys.R) && currentKeyBoardState.IsKeyUp(Keys.R)) {
                commandQueue.QueueCommand(commandFactory.CreateCommand("ReverseGravity"));
            }
            _lastKeyBoardState = currentKeyBoardState;
        }

        public void HandleRealTimeInput(CommandQueue commandQueue, ICommandFactory commandFactory) {
            KeyboardState currentKeyBoardState = Keyboard.GetState();

            if (currentKeyBoardState.IsKeyDown(Keys.Left) || currentKeyBoardState.IsKeyDown(Keys.A)) {
                commandQueue.QueueCommand(commandFactory.CreateCommand("Left"));
            }
            if (currentKeyBoardState.IsKeyDown(Keys.Right) || currentKeyBoardState.IsKeyDown(Keys.D)) {
                commandQueue.QueueCommand(commandFactory.CreateCommand("Right"));
            }
            if (currentKeyBoardState.IsKeyDown(Keys.Space)) {
                commandQueue.QueueCommand(commandFactory.CreateCommand("Shoot"));
            }
            if (currentKeyBoardState.IsKeyDown(Keys.W) || currentKeyBoardState.IsKeyDown(Keys.Up)) {
                commandQueue.QueueCommand(commandFactory.CreateCommand("Jump"));
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
