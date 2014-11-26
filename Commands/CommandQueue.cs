using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gengine.Commands {
    public class CommandQueue {
        private readonly Queue<string> commandQueue = new Queue<string>();

        public void QueueCommand(string command) {
            commandQueue.Enqueue(command);
        }

        public void Clear() {
            commandQueue.Clear();
        }

        public bool HasCommands() {
            return commandQueue.Count > 0;
        }

        public string GetNext() {
            return commandQueue.Dequeue();
        }
    }
}
