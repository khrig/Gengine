using System.Collections.Generic;

namespace Gengine.Commands {
    public class SimpleCommandFactory : ICommandFactory {
        private readonly Dictionary<string, ICommand> _commands;
        public SimpleCommandFactory() {
            _commands = new Dictionary<string, ICommand>();
        }

        public ICommand CreateCommand(string name) {
            if (!_commands.ContainsKey(name))
                _commands.Add(name, new Command(name));
            return _commands[name];
        }
    }
}
