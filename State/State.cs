namespace Gengine.State {
    public abstract class State {
        public StateManager StateManager { get; set; }

        // the bool return value marks if its fall through or not
        public abstract bool Update(float deltaTime);
        public abstract bool Draw();
        public abstract void HandleInput(string key);
        public abstract void Init();
    }
}