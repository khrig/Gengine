using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gengine.Entities
{
    public class PositionComponent : EntityComponent {
        public Vector2 Position { get; private set; }

        public override void Update(float deltaTime) {
            base.Update(deltaTime);
        }
    }
}
