using Gengine.Commands;
using Gengine.Input;

namespace Gengine.Entities {
    public class InputComponent : EntityComponent {
        private readonly CommandQueue commandQueue;
        public InputComponent() {
            commandQueue = new CommandQueue();
        }

        public override void Update(float deltaTime) {
            InputManager.Instance.HandleRealTimeInput(commandQueue);
            while (commandQueue.HasCommands()) {
                Command(commandQueue.GetNext());
            }
            commandQueue.Clear();
            base.Update(deltaTime);
        }

        private void Command(string command) {
            /*
            if (message == "Space")
                Position = new Vector2(Position.X, Position.Y - 20);
             * */            
            if (command == "Left")
                Entity.GetComponent<MovementComponent>().Direction = -1;
            if (command == "Right")
                Entity.GetComponent<MovementComponent>().Direction = 1;
        }
    }
}
