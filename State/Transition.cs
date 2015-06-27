namespace Gengine.State {
    public abstract class Transition : State {
        public string NextStateId { get; set; }
    }
}
