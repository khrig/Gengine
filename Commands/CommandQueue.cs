using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gengine.Commands {
    public class CommandQueue {
        private readonly Queue<ICommand> commandQueue = new Queue<ICommand>();

        public void QueueCommand(ICommand command) {
            commandQueue.Enqueue(command);
        }

        public void Clear() {
            commandQueue.Clear();
        }

        public bool HasCommands() {
            return commandQueue.Count > 0;
        }

        public ICommand GetNext() {
            return commandQueue.Dequeue();
        }
    }
}
