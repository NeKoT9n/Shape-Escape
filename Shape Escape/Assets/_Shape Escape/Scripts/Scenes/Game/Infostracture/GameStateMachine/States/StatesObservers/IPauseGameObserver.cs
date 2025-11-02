using System.Collections;
using UnityEngine;

namespace Assets._Shape_Escape.Scripts.Scenes.Game.Infostracture.GameStateMachine.States.StatesObservers
{
    public interface IPauseGameObserver 
    {
        public void OnGamePaused();
        public void OnGameResumed();
        
    }
}