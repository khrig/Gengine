using System;
using System.Collections.Generic;
using System.Linq;
using Gengine.Commands;
using Gengine.Entities;
using Gengine.Rendering;
using Gengine.UI;
using Microsoft.Xna.Framework;

namespace Gengine.State {
    public class BaseMenuState : State {
        private readonly List<MenuOption> _options;
        private readonly List<MenuOption> _title;
        private int _selectedOption;

        private Action<string> _onAction;
        protected string SelectedOption { get { return _options[_selectedOption].Text; } }

        public BaseMenuState() {
            _options = new List<MenuOption>(10);
            _title = new List<MenuOption>(1);
        }

        public override bool Update(float deltaTime) {
            for (var i = 0;i < _options.Count;i++) {
                _options[i].Color = i == _selectedOption ? Color.Blue : Color.White;
            }
            return false;
        }

        public override void Init(){
        }

        public override void Unload() {
            _options.Clear();
            _title.Clear();
            _selectedOption = 0;
        }

        public override IEnumerable<IRenderable> GetRenderTargets(){
            return Enumerable.Empty<IRenderable>();
        }

        public override IEnumerable<IRenderableText> GetTextRenderTargets() {
            return _options.Concat(_title);
        }

        protected void SetTitle(MenuOption title) {
            _title.Add(title);
        }

        protected void AddOption(MenuOption option){
            _options.Add(option);
        }

        protected void SetAction(Action<string> onEnter){
            _onAction = onEnter;
        }

        protected override bool HandleCommand(ICommand command) {
            switch (command.Name) {
                case "Up":
                    MoveUp();
                    break;
                case "Down":
                    MoveDown();
                    break;
                default:
                    if (_onAction == null)
                        throw new Exception("Action for handling commands not set");
                    _onAction(command.Name);
                    break;
            }
            return false;
        }
        
        private void MoveDown() {
            _selectedOption++;
            if (_selectedOption >= _options.Count)
                _selectedOption = 0;
        }

        private void MoveUp() {
            _selectedOption--;
            if (_selectedOption < 0)
                _selectedOption = _options.Count - 1;
        }
    }
}
