using Gengine.Commands;
using Microsoft.Xna.Framework.Input;

namespace Gengine.Input {
    public class InputManager {
        private static readonly InputManager instance = new InputManager();
        private InputManager() { }
        public static InputManager Instance { get { return instance; } }

        private KeyboardState lastKeyBoardState;
        //private MouseState lastMouseState;

        public void HandleInput(CommandQueue commandQueue, ICommandFactory commandFactory) {
            commandQueue.Clear();

            KeyboardState currentKeyBoardState = Keyboard.GetState();
            if (lastKeyBoardState.IsKeyDown(Keys.Up) && currentKeyBoardState.IsKeyUp(Keys.Up)) {
                commandQueue.QueueCommand(commandFactory.CreateCommand("Up"));
            }
            if (lastKeyBoardState.IsKeyDown(Keys.Down) && currentKeyBoardState.IsKeyUp(Keys.Down)) {
                commandQueue.QueueCommand(commandFactory.CreateCommand("Down"));
            }
            if (lastKeyBoardState.IsKeyDown(Keys.Enter) && currentKeyBoardState.IsKeyUp(Keys.Enter)) {
                commandQueue.QueueCommand(commandFactory.CreateCommand("Enter"));
            } 
            if (lastKeyBoardState.IsKeyDown(Keys.Escape) && currentKeyBoardState.IsKeyUp(Keys.Escape)) {
                commandQueue.QueueCommand(commandFactory.CreateCommand("Escape"));
            }
            if (lastKeyBoardState.IsKeyDown(Keys.P) && currentKeyBoardState.IsKeyUp(Keys.P)) {
                commandQueue.QueueCommand(commandFactory.CreateCommand("Pause"));
            }
            if (lastKeyBoardState.IsKeyDown(Keys.U) && currentKeyBoardState.IsKeyUp(Keys.U)) {
                commandQueue.QueueCommand(commandFactory.CreateCommand("Debug"));
            }
            lastKeyBoardState = currentKeyBoardState;
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
            if (currentKeyBoardState.IsKeyDown(Keys.W)) {
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
