using System.Collections.Generic;
using Zenject;

namespace Assets._Shape_Escape.Scripts.Scenes.Game.Infostracture.GameStateMachine.States
{
    public class PlayGameState : ITickableState
    {

        [Inject] private List<General.ITickable> _tickables;

        private bool _start = false;

        public void Enter()
        {
            _start = true;
        }

        public void Exit()
        {
            _start = false;
        }

        public void Tick()
        {
            if (_start == false) return; 

            foreach (var tickable in _tickables) 
            {
                tickable.Tick();
            }
        }
    }
}