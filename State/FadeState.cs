using System;
using System.Collections.Generic;
using System.Linq;
using Gengine.Commands;
using Gengine.Rendering;
using Microsoft.Xna.Framework;

namespace Gengine.State {
    public class FadeTransition : Transition {
        private int _alphaValue = 1;
        private readonly float _fadeDelay = 1f;
        private readonly Action _init;
        private bool _fadeComplete;
        private float _fadeElapsed;

        public FadeTransition(float fadeDelay, string nextState) {
            _fadeDelay = fadeDelay;
            NextStateId = nextState;
        }

        public FadeTransition(float fadeDelay, string nextState, Action init){
            _fadeDelay = fadeDelay;
            NextStateId = nextState;
            _init = init;
        }

        public override void Setup() {
        }

        public override bool Update(float deltaTime){
            if (!_fadeComplete){
                _fadeElapsed += deltaTime;
                if (_fadeElapsed >= _fadeDelay*deltaTime){
                    FadeIn();
                }
            }
            else{
                StateManager.PopState();
            }
            return false;
        }

        public override void Run(){
            _fadeElapsed = 0;
            _fadeComplete = false;
            _alphaValue = 1;
            SetColor(Color.Black);

            if(_init != null)
                _init();
        }

        private void FadeIn() {
            _alphaValue += 3;
            _fadeComplete = _alphaValue >= 255;
            SetColor(new Color(255, 255, 255, (byte)MathHelper.Clamp(_alphaValue, 0, 255)));
        }

        public override void Unload(){
        }

        protected override bool HandleCommand(ICommand command){
            return true;
        }

        public override IEnumerable<IRenderable> GetRenderTargets() {
            return Enumerable.Empty<IRenderable>();
        }

        public override IEnumerable<IEnumerable<IRenderable>> GetRenderLayers() {
            return Enumerable.Empty<IEnumerable<IRenderable>>();
        }

        public override IEnumerable<IRenderableText> GetTextRenderTargets() {
            return Enumerable.Empty<IRenderableText>();
        }
    }
}
