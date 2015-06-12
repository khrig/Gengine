using Gengine.Commands;
using Gengine.Input;

namespace Gengine.Entities {
    public class InputComponent : EntityComponent {
        private readonly CommandQueue _commandQueue;
        private readonly ICommandFactory _commandFactory;
        public InputComponent() {
            _commandQueue = new CommandQueue();
            _commandFactory = new ComponentCommandFactory();
        }

        public override void Update(float deltaTime) {
            InputManager.Instance.HandleRealTimeInput(_commandQueue, _commandFactory);
            while (_commandQueue.HasCommands()) {
                Command(_commandQueue.GetNext());
            }
            _commandQueue.Clear();
            base.Update(deltaTime);
        }

        private void Command(ICommand command) {
            if (command.Name == "Left")
                Entity.GetComponent<MovementComponent>().Direction = -1;
            if (command.Name == "Right")
                Entity.GetComponent<MovementComponent>().Direction = 1;
        }

        private class ComponentCommandFactory : ICommandFactory {
            public ICommand CreateCommand(string name) {
                return new Command(name);
            }
        }
    }
}
