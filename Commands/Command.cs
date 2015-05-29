using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gengine.Commands {
    public class Command : ICommand {
        private string _name;
        public string Name {
            get { return _name; }
        }

        public Command(string name) {
            _name = name;
        }
    }
}
