using System.Collections.Generic;
using System.Linq;
using Gengine.Commands;
using Gengine.Entities;
using Microsoft.Xna.Framework;

namespace Gengine.State {
    public class FadeTransition : Transition {
        private int _alphaValue = 1;
        private readonly float _fadeDelay = 1f;
        private bool _fadeComplete;
        private float _fadeElapsed;

        public FadeTransition(float fadeDelay, string nextState){
            _fadeDelay = fadeDelay;
            NextStateId = nextState;
        }

        public override bool Update(float deltaTime){
            if (!_fadeComplete){
                _fadeElapsed += deltaTime;
                if (_fadeElapsed >= _fadeDelay*deltaTime){
                    _alphaValue += 3;
                    _fadeComplete = _alphaValue >= 255;
                    SetColor(new Color(255, 255, 255, (byte) MathHelper.Clamp(_alphaValue, 0, 255)));
                }
            }
            else{
                StateManager.PopState();
            }
            return false;
        }

        public override void Init(){
            _fadeElapsed = 0;
            _fadeComplete = false;
            _alphaValue = 1;
            SetColor(Color.Black);
        }

        public override void Unload(){
        }

        public override void HandleCommands(CommandQueue commandQueue){
        }

        public override IEnumerable<IRenderable> GetRenderTargets() {
            return Enumerable.Empty<IRenderable>();
        }

        public override IEnumerable<IRenderableText> GetTextRenderTargets() {
            return Enumerable.Empty<IRenderableText>();
        }
    }
}
