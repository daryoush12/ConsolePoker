using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerGame
{
    class GameStateHandler
    {
        private GameState _currentState;

        private GameState _nextState;

        public string gamestatetring;

        Dictionary<Type, GameState> _availableStates;

        public event Action<GameState> onStateChanged;


        public void RefreshState()
        {
            if (_currentState == null && _availableStates != null)
            {
                SwitchToNewState(_availableStates.Keys.First());
            }

            //Take in next state
            var nextState = _currentState?.Tick();

            if (nextState != null && nextState != _currentState?.GetType())
            {
                SwitchToNewState(nextState);
            }
        }


        /// <summary>
        /// Sets currently available states
        /// </summary>
        /// <param name="states"></param>
        public void SetStates(Dictionary<Type, GameState> states)
        {
            this._availableStates = states;
        }

        /// <summary>
        /// Switches to new state in the state dictionary
        /// </summary>
        /// <param name="nextstate"></param>
        void SwitchToNewState(Type nextstate)
        {
            _currentState?.OnStateExit();
            _currentState = _availableStates[nextstate];
            onStateChanged?.Invoke(_currentState);
            _currentState?.OnStateEnter();
            gamestatetring = _currentState.ToString();
            Console.WriteLine("Game State Changed To: " + _currentState.ToString());
        }
    }
}
