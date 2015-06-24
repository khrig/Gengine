namespace Gengine.EntityComponentSystem {
    public abstract class Component {
        protected Component() {
            Id = Entity.RegisterComponent(this);
        }

        public int Id { get; private set; }
    }
}
