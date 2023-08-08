using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StateMachine
{
    public class StateMachine : MonoBehaviour
    {
        /// <summary>
        /// State in which state machine is in currently
        /// </summary>
        private State _currentState;
        
        /// <summary>
        /// State in which state machine starts to operate (will be first _currentState)
        /// </summary>
        protected State BaseState;
        
        
        void Start()
        {
            _currentState = BaseState;
            _currentState.Start(this);
            _currentState.StateEntered(this);
        }

        void Update()
        {
            _currentState.Update();
        }

        private void FixedUpdate()
        {
            _currentState.FixedUpdate();
        }

        
        /// <summary>
        /// Used to change state to the given one
        /// it sends StateExited() on the old state
        /// and StateEntered() on new state (which is given as a state parameter)
        /// </summary>
        /// <param name="state">New state in which state machine will transition to</param>
        public void ChangeState(State state)
        {
            _currentState.StateExited();
            _currentState = state;
            _currentState.StateEntered(this);
        }

    }
}

