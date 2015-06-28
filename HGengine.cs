using Gengine.Commands;
using Gengine.Input;
using Gengine.Rendering;
using Gengine.Resources;
using Gengine.State;
using Gengine.Utils;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Gengine {
    public class HGengine {
        private readonly Game _gameRef;
        private readonly GraphicsDeviceManager _graphics;
        private RenderingSystem _renderingSystem;
        private readonly IResourceManager _resourceManager;
        private readonly ICommandFactory _commandFactory;
        private IWorld _world;
        private StateManager _stateManager;
        private readonly CommandQueue _commandQueue;

        public HGengine(Game gameRef, GraphicsDeviceManager graphics){
            _gameRef = gameRef;
            _graphics = graphics;
            _commandQueue = new CommandQueue();
            _commandFactory = new SimpleCommandFactory();
            _resourceManager = new ResourceManager();
            TextExtensions.AddResourceManager(_resourceManager);
        }

        public void Initialize(int gameWidth, int gameHeight, int windowWidth, int windowHeight) {
            _world = new TwoDWorld(gameWidth, gameHeight, windowWidth, windowHeight);
            _renderingSystem = new RenderingSystem(_graphics, _resourceManager, _world);
            _graphics.PreferredBackBufferWidth = windowWidth;
            _graphics.PreferredBackBufferHeight = windowHeight;
            _graphics.ApplyChanges();

            InitSystems();
        }

        public void InitializeFullScreen(int gameWidth, int gameHeight) {
            int windowWidth = _graphics.PreferredBackBufferWidth = _graphics.GraphicsDevice.DisplayMode.Width;
            int windowHeight = _graphics.PreferredBackBufferHeight = _graphics.GraphicsDevice.DisplayMode.Height;
            _graphics.IsFullScreen = true;
            _world = new TwoDWorld(gameWidth, gameHeight, windowWidth, windowHeight);
            _renderingSystem = new RenderingSystem(_graphics, _resourceManager, _world);
            _graphics.ApplyChanges();

            InitSystems();
        }
        
        public void Update(float dt){
            _stateManager.ChangeState();
            if (_stateManager.IsEmpty())
                _gameRef.Exit();

            InputManager.Instance.HandleInput(_commandQueue, _commandFactory);
            _stateManager.HandleCommands(_commandQueue);
            _stateManager.Update(dt);
        }

        public void Draw(){
            _renderingSystem.DrawWithRenderTarget(_stateManager.GetRenderTargets(), 
                _stateManager.GetRenderText(), 
                _stateManager.GetRenderTransformation(), 
                _stateManager.GetRenderColor());
        }

        public void Unload() {
            
        }

        public void AddState(string name, State.State state) {
            _stateManager.Add(name, state);
        }

        public void StartWith(string name) {
            _stateManager.PushState(name);
        }

        private void InitSystems() {
            _stateManager = new StateManager(_world);
        }

        public void AddFont(string fontName, string fontPath){
            _resourceManager.AddFont(fontName, _gameRef.Content.Load<SpriteFont>(fontPath));
        }

        public void AddTexture(string spriteName, string spritePath) {
            _resourceManager.AddTexture(spriteName, _gameRef.Content.Load<Texture2D>(spritePath));
        }

        public void SetDebugDraw(bool enable){
            _renderingSystem.DebugDraw = enable;
        }
    }
}
