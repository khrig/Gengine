using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gengine.Commands {
    public class CommandQueue {
        private readonly Queue<ICommand> _commandQueue = new Queue<ICommand>();

        public void QueueCommand(ICommand command) {
            _commandQueue.Enqueue(command);
        }

        public void Clear() {
            _commandQueue.Clear();
        }

        public bool HasCommands() {
            return _commandQueue.Count > 0;
        }

        public ICommand GetNext() {
            return _commandQueue.Dequeue();
        }
    }
}
