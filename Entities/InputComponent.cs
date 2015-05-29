using Gengine.Commands;
using Gengine.Input;

namespace Gengine.Entities {
    public class InputComponent : EntityComponent {
        private readonly CommandQueue commandQueue;
        private readonly ICommandFactory commandFactory;
        public InputComponent() {
            commandQueue = new CommandQueue();
        }

        public override void Update(float deltaTime) {
            InputManager.Instance.HandleRealTimeInput(commandQueue, commandFactory);
            while (commandQueue.HasCommands()) {
                Command(commandQueue.GetNext());
            }
            commandQueue.Clear();
            base.Update(deltaTime);
        }

        private void Command(ICommand command) {
            /*
            if (message == "Space")
                Position = new Vector2(Position.X, Position.Y - 20);
             * */            
            if (command.Name == "Left")
                Entity.GetComponent<MovementComponent>().Direction = -1;
            if (command.Name == "Right")
                Entity.GetComponent<MovementComponent>().Direction = 1;
        }

        private class ComponentCommandFactory : ICommandFactory {
            public ICommand CreateCommand(string name) {
                throw new System.NotImplementedException();
            }
        }
    }
}
